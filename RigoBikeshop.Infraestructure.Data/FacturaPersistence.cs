using Microsoft.Data.SqlClient;
using System.Data;

using RigoBikeshop.Domain.Entities;

namespace RigoBikeshop.Infraestructure.Data
{
    public static class FacturaPersistence
    {

        
        public static DataTable GetAllFacturas()
        {

            if (Conexion.EjecutarConsultaAsync("GetAllFacturaEncabezado", CommandType.StoredProcedure).Rows.Count > 0)
            {
                return Conexion.EjecutarConsultaAsync("GetAllFacturaEncabezado", CommandType.StoredProcedure);
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
            SqlParameter Total = new SqlParameter("@P_Total", oFacturaEncabezado.Total);
            SqlParameter FechaFactura = new SqlParameter("@P_FechaFactura", oFacturaEncabezado.FechaFactura);
            

            listaInsertar.Add(NumFac);
            listaInsertar.Add(IdClient);
            listaInsertar.Add(Total);
            listaInsertar.Add(FechaFactura);
            listaInsertar.Add(paramId);

            Conexion.EjecutarOperacion("FacturaEncabezadoInsert", listaInsertar, CommandType.StoredProcedure);
            int idEncabezado = (int)paramId.Value;
           
        }

        public static void UpdateFactura(FacturaEncabezado oFacturaEncabezado)
        {
            List<SqlParameter> listaInsertar = new List<SqlParameter>();

            SqlParameter IdFacturaEncabezado = new SqlParameter("@P_IdFacturaEncabezado", oFacturaEncabezado.IdEncabezado);
            SqlParameter NumFac = new SqlParameter("@P_IdProducto", oFacturaEncabezado.NumeroFactura);
            SqlParameter Total = new SqlParameter("@P_Total", oFacturaEncabezado.Total);
            SqlParameter FechaFactura = new SqlParameter("@P_FechaFactura", oFacturaEncabezado.FechaFactura);

            listaInsertar.Add(IdFacturaEncabezado);
            listaInsertar.Add(NumFac);
            listaInsertar.Add(Total);
            listaInsertar.Add(FechaFactura);

            Conexion.EjecutarOperacion("FacturaEncabezadoUpdate", listaInsertar, CommandType.StoredProcedure);
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
