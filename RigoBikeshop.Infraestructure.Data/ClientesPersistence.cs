using Microsoft.Data.SqlClient;
using System.Data;

using RigoBikeshop.Domain.Entities;
namespace RigoBikeshop.Infraestructure.Data
{
    public static class ClientesPersistence
    {
        public static DataTable GetAllClientes()
        {

            if (Conexion.EjecutarConsulta("GetAllClientes", CommandType.StoredProcedure).Rows.Count > 0)
            {
                return Conexion.EjecutarConsulta("GetAllClientes", CommandType.StoredProcedure);
            }
            else
            {
                return null;
            }
        }

        public static DataTable GetIdCliente(int idCliente)
        {

            List<SqlParameter> lista = new List<SqlParameter>();
            SqlParameter codigo = new SqlParameter("@P_IdCliente", idCliente);
            lista.Add(codigo);
            return Conexion.EjecutarConsulta("GetIdClientes", lista, CommandType.StoredProcedure);

        }

        public static void CreateCliente(Clientes oClientes)
        {
            List<SqlParameter> listaInsertar = new List<SqlParameter>();


            SqlParameter codigo = new SqlParameter("@P_CodigoCliente", oClientes.CodigoCliente);
            SqlParameter nombre = new SqlParameter("@P_NombreCliente", oClientes.NombreCliente);
            SqlParameter direc = new SqlParameter("@P_DireccionCliente", oClientes.DireccionCliente);
            SqlParameter telefono = new SqlParameter("@P_TelefonoCliente", oClientes.TelefonoCliente);


            listaInsertar.Add(codigo);
            listaInsertar.Add(nombre);
            listaInsertar.Add(direc);
            listaInsertar.Add(telefono);

            Conexion.EjecutarOperacion("ClientesInsert", listaInsertar, CommandType.StoredProcedure);

        }

        public static void UpdateCliente(Clientes oCliente)
        {
            List<SqlParameter> listaInsertar = new List<SqlParameter>();


            SqlParameter codigo = new SqlParameter("@P_CodigoCliente", oCliente.CodigoCliente);
            SqlParameter nombre = new SqlParameter("@P_NombreCliente", oCliente.NombreCliente);
            SqlParameter direc = new SqlParameter("@P_DireccionCliente", oCliente.DireccionCliente);
            SqlParameter telefono = new SqlParameter("@P_TelefonoCliente", oCliente.TelefonoCliente);

            listaInsertar.Add(codigo);
            listaInsertar.Add(nombre);
            listaInsertar.Add(direc);
            listaInsertar.Add(telefono);

            Conexion.EjecutarOperacion("ClientesUpdate", listaInsertar, CommandType.StoredProcedure);
        }

        public static void DeleteCliente(Clientes oCliente)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            SqlParameter codigo = new SqlParameter("@P_IdCliente", oCliente.IdCliente);

            lista.Add(codigo);

            Conexion.EjecutarOperacion("ClientesDelete", lista, CommandType.StoredProcedure);
        }
    }
}
