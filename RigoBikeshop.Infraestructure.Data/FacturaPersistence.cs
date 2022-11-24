using Microsoft.Data.SqlClient;
using System.Data;

using RigoBikeshop.Domain.Entities;

namespace RigoBikeshop.Infraestructure.Data
{
    public static class FacturaPersistence
    {

        //public readOnly Poducto prod;
        public static DataTable GetAllFacturas()
        {

            if (Conexion.EjecutarConsulta("FacturaEncabezadoSelectAll", CommandType.StoredProcedure).Rows.Count > 0)
            {
                return Conexion.EjecutarConsulta("FacturaEncabezadoSelectAll", CommandType.StoredProcedure);
            }
            else
            {
                return null;
            }
        }

        public static DataTable GetIdFactura(int IdFacturaEncabezado)
        {

            List<SqlParameter> lista = new List<SqlParameter>();
            SqlParameter codigo = new SqlParameter("@P_IdFacturaEncabezado", IdFacturaEncabezado);
            lista.Add(codigo);
            return Conexion.EjecutarConsulta("FacturaEncabezadoSelectID", lista, CommandType.StoredProcedure);

        }

        public static void CreateFactura(FacturaEncabezado oFacturaEncabezado)
        {
            List<SqlParameter> listaInsertar = new List<SqlParameter>();
            SqlParameter paramId = new SqlParameter("@Identity", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            SqlParameter IdClient = new SqlParameter("@P_IdCliente", oFacturaEncabezado.IdCliente);
            SqlParameter NumFac = new SqlParameter("@P_NumeroFactura", oFacturaEncabezado.NumeroFactura);
            SqlParameter CodigoCliente = new SqlParameter("@P_CodigoEmpresa", oFacturaEncabezado.CodigoEmpresa);
            SqlParameter CodigoEmpresa = new SqlParameter("@P_CodigoCliente", oFacturaEncabezado.CodigoCliente);
            SqlParameter Total = new SqlParameter("@P_Total", oFacturaEncabezado.Total);
            SqlParameter FechaFactura = new SqlParameter("@P_FechaFactura", oFacturaEncabezado.FechaFactura);

            listaInsertar.Add(NumFac);
            listaInsertar.Add(IdClient);
            listaInsertar.Add(CodigoCliente);
            listaInsertar.Add(CodigoEmpresa);
            listaInsertar.Add(Total);
            listaInsertar.Add(FechaFactura);
            listaInsertar.Add(paramId);

            Conexion.EjecutarOperacion("FacturaEncabezadoInsert", listaInsertar, CommandType.StoredProcedure);
            int idEncabezado = (int)paramId.Value;
            foreach (FacturaDetalle Linea in oFacturaEncabezado.Lineas)
            {
                List<SqlParameter> ListaDetalle = new List<SqlParameter>();

                Linea.IdFacturaEncabezado = idEncabezado;

                SqlParameter IdFacDetalle = new SqlParameter("@P_Identity", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };

                SqlParameter IdFacEnc = new SqlParameter("@P_IdFacturaEncabezado", Linea.IdFacturaEncabezado);
                SqlParameter IdProd = new SqlParameter("@P_IdProducto", Linea.IdProducto);
                SqlParameter CodigoProducto = new SqlParameter("@P_CodigoProducto", Linea.CodigoProducto);
                SqlParameter NombreProducto = new SqlParameter("@P_NombreProducto", Linea.NombreProducto);
                SqlParameter cantidad = new SqlParameter("@P_cantidad", Linea.Cantidad);

                ListaDetalle.Add(IdFacEnc);
                ListaDetalle.Add(IdProd);
                ListaDetalle.Add(CodigoProducto);
                ListaDetalle.Add(NombreProducto);
                ListaDetalle.Add(cantidad);
                ListaDetalle.Add(IdFacDetalle);// agrega el idDetalle

                Conexion.EjecutarOperacion("FacturaDetalleInsert", ListaDetalle, CommandType.StoredProcedure);
                int idDetalle = (int)IdFacDetalle.Value;
            }

        }

        public static void UpdateFactura(FacturaEncabezado oFacturaEncabezado)
        {
            List<SqlParameter> listaInsertar = new List<SqlParameter>();

            SqlParameter IdFacturaEncabezado = new SqlParameter("@P_IdFacturaEncabezado", oFacturaEncabezado.IdEncabezado);
            SqlParameter NumFac = new SqlParameter("@P_IdProducto", oFacturaEncabezado.NumeroFactura);
            SqlParameter CodigoCliente = new SqlParameter("@P_CodigoEmpresa", oFacturaEncabezado.CodigoEmpresa);
            SqlParameter CodigoEmpresa = new SqlParameter("@P_CodigoClient", oFacturaEncabezado.CodigoCliente);
            SqlParameter Total = new SqlParameter("@P_Total", oFacturaEncabezado.Total);
            SqlParameter FechaFactura = new SqlParameter("@P_FechaFactura", oFacturaEncabezado.FechaFactura);

            listaInsertar.Add(IdFacturaEncabezado);
            listaInsertar.Add(NumFac);
            listaInsertar.Add(CodigoCliente);
            listaInsertar.Add(CodigoEmpresa);
            listaInsertar.Add(Total);
            listaInsertar.Add(FechaFactura);

            Conexion.EjecutarOperacion("FacturaEncabezadoUpdate", listaInsertar, CommandType.StoredProcedure);

            foreach (FacturaDetalle Linea in oFacturaEncabezado.Lineas)
            {
                List<SqlParameter> ListaDetalle = new List<SqlParameter>();

                SqlParameter IdFacEnc = new SqlParameter("@P_IdFacturaEncabezado", Linea.IdFacturaEncabezado);
                SqlParameter IdProd = new SqlParameter("@P_IdProducto", Linea.IdProducto);
                SqlParameter CodigoProducto = new SqlParameter("@P_CodigoProducto", Linea.CodigoProducto);
                SqlParameter NombreProducto = new SqlParameter("@P_NombreProducto", Linea.NombreProducto);
                SqlParameter cantidad = new SqlParameter("@P_cantidad", Linea.Cantidad);

                ListaDetalle.Add(IdFacEnc);
                ListaDetalle.Add(IdProd);
                ListaDetalle.Add(CodigoProducto);
                ListaDetalle.Add(NombreProducto);
                ListaDetalle.Add(cantidad);

                Conexion.EjecutarOperacion("FacturaDetalleUpdate", listaInsertar, CommandType.StoredProcedure);
            }
        }

        public static void DeleteFactura(FacturaEncabezado ofacturaEncabezado)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            SqlParameter codigo = new SqlParameter("@P_IdFacturaEncabezado", ofacturaEncabezado.IdEncabezado);

            lista.Add(codigo);

            Conexion.EjecutarOperacion("FacturaEncabezadoDelete", lista, CommandType.StoredProcedure);
        }

    }
}
