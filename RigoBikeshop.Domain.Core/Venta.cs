
using System.Data;

using RigoBikeshop.Domain.Entities;
using RigoBikeshop.Infraestructure.Data;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data.Common;
using System.Reflection;

namespace RigoBikeshop.Domain.Core
{
    public static class Venta
    {
        static readonly Producto prod = new Producto();
        static readonly FacturaVentaDTO VtaDto = new FacturaVentaDTO(); 
        static readonly FacturaEncabezado FacEnc = new FacturaEncabezado();

        public static string ListarFacturaVenta()
        {
            DataTable dtConsultaProductos;
            string DtaTblJSONStr=string.Empty;
            
            dtConsultaProductos = ProductoPersistence.GetAllProductos();
              
            DtaTblJSONStr = JsonConvert.SerializeObject(dtConsultaProductos);  

            return DtaTblJSONStr;
        }

        public static string ConsultarFacturaVenta(int idFacturaEncabezado)
        {
            DataTable dtConsultaFactura;
            dtConsultaFactura = FacturaPersistence.GetIdFactura(idFacturaEncabezado);

            var lstFactura = JsonConvert.SerializeObject(dtConsultaFactura);
            return lstFactura;
        }

        public static string ConsultarProductoId(int idProducto)
        {

            DataTable dtConsultaProducto;
            dtConsultaProducto = ProductoPersistence.GetIdProducto(idProducto);

            var lstProducto = JsonConvert.SerializeObject(dtConsultaProducto);

            return lstProducto;
        }

        public static string ConsultarIdCliente(int idCliente)
        {

            DataTable dtConsultaCliente;

            dtConsultaCliente = ClientesPersistence.GetIdCliente(idCliente);

            var lstCliente = JsonConvert.SerializeObject(dtConsultaCliente);

            return lstCliente;
        }

        public static IEnumerable<Clientes> ListarCliente()
        {


            var lstCliente = ConvertDataTable<Clientes>(ClientesPersistence.GetAllClientes());

            return lstCliente;

        }

        public static IEnumerable<Producto> ListarProducto()
        {

               var lstProducto = ConvertDataTable<Producto>(ProductoPersistence.GetAllProductos());

            return lstProducto;

        }
        public static FacturaDetalle AddLine(int IdProducto, int IdFacturaEncabezado, int Cantidad)
        {
            //check Not Zero Cantidad
            if (Cantidad <= 0)
            {
                throw new ArgumentException("No se puede Facturar con cantidades iguales o menores de Cero");
            }


            //create new factura detalle
                var newFacturaDetalle = new FacturaDetalle()
                {
                    IdFacturaEncabezado = IdFacturaEncabezado,
                    IdProducto = IdProducto,
                    Cantidad = Cantidad
                };

            //add factura detalle
            VtaDto.Lineas.Add(newFacturaDetalle);
            VtaDto.Total = prod.PrecioUnitario * Cantidad;

            return newFacturaDetalle;
        }

        public static void RegistrarFacturaVenta(FacturaVentaDTO oFacturaVta)
        {
            decimal Subtotal = 0M; 
            try
            {
                FacEnc.IdCliente = oFacturaVta.IdCliente;
                FacEnc.IdEncabezado = oFacturaVta.IdEncabezado;
                FacEnc.NumeroFactura = oFacturaVta.NumeroFactura;
                FacEnc.FechaFactura = oFacturaVta.FechaFactura;


                FacturaPersistence.CreateFactura(FacEnc);
                foreach (var linea in VtaDto.Lineas)
                {
                    FacturaDetallePersistence.CreateFacturaDetalle(linea, FacEnc.IdEncabezado);
                    Subtotal += VtaDto.Total;
                }

                FacEnc.Total = Subtotal;
            }
            catch (Exception ex )
            {
                throw ex;
            }
            
        }

        private static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();
            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
    }
}
