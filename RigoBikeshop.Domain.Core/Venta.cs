
using System.Data;

using RigoBikeshop.Domain.Entities;
using RigoBikeshop.Infraestructure.Data;

namespace Domain.core
{
    public static class Venta
    {
        static readonly Producto prod = new Producto();
        static readonly FacturaVentaDTO VtaDto = new FacturaVentaDTO(); 
        static readonly FacturaEncabezado FacEnc = new FacturaEncabezado();

        public static List<DataRow> ListarFacturaVenta()
        {
            DataTable dtListaFactura;
            dtListaFactura = FacturaPersistence.GetAllFacturas();

            List<DataRow> lstFactura = dtListaFactura.AsEnumerable().ToList();
            return lstFactura;
        }

        public static List<DataRow> ConsultarFacturaVenta(int idFacturaEncabezado)
        {
            DataTable dtConsultaFactura;
            dtConsultaFactura = FacturaPersistence.GetIdFactura(idFacturaEncabezado);

            List<DataRow> lstFactura = dtConsultaFactura.AsEnumerable().ToList();
            return lstFactura;
        }

        public static List<DataRow> ConsultarProductoId(int idProducto)
        {

            DataTable dtConsultaProducto;
            dtConsultaProducto = ProductoPersistence.GetIdProducto(idProducto);

            List<DataRow> lstProducto = dtConsultaProducto.AsEnumerable().ToList();

            return lstProducto;
        }

        public static List<DataRow> ConsultarIdCliente(int idCliente)
        {

            DataTable dtConsultaCliente;
            dtConsultaCliente = ClientesPersistence.GetIdCliente(idCliente);

            List<DataRow> lstCliente = dtConsultaCliente.AsEnumerable().ToList();

            return lstCliente;
        }

        public static List<DataRow> ListarCliente()
        {

            DataTable dtConsultaCliente;
            dtConsultaCliente = ClientesPersistence.GetAllClientes();

            List<DataRow> lstCliente = dtConsultaCliente.AsEnumerable().ToList();

            return lstCliente;
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



    }
}
