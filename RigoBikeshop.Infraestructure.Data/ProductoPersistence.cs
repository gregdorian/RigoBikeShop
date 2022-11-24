using Microsoft.Data.SqlClient;
using System.Data;

using RigoBikeshop.Domain.Entities;

namespace RigoBikeshop.Infraestructure.Data
{
    public class ProductoPersistence
    {
        public DataTable GetAllProductos()
        {

            if (Conexion.EjecutarConsulta("GetAllProducto", CommandType.StoredProcedure).Rows.Count > 0)
            {
                return Conexion.EjecutarConsulta("GetAllProducto", CommandType.StoredProcedure);
            }
            else
            {
                return null;
            }
        }

        public DataTable GetIdProducto(int idProducto)
        {

            List<SqlParameter> lista = new List<SqlParameter>();
            SqlParameter codigo = new SqlParameter("@P_IdProducto", idProducto);
            lista.Add(codigo);
            return Conexion.EjecutarConsulta("ProductosSelectID", lista, CommandType.StoredProcedure);

        }

        public void CreateProducto(Producto oProductos)
        {
            List<SqlParameter> listaInsertar = new List<SqlParameter>();

            SqlParameter codigo = new SqlParameter("@P_CodigoProducto", oProductos.CodigoProducto);
            SqlParameter nombre = new SqlParameter("@P_NombreProducto", oProductos.NombreProducto);
            SqlParameter preciounit = new SqlParameter("@P_DireccionProducto", oProductos.PrecioUnitario);
            SqlParameter fechaIng = new SqlParameter("@P_FechaIngreso", oProductos.FechaIngreso);

            listaInsertar.Add(codigo);
            listaInsertar.Add(nombre);
            listaInsertar.Add(preciounit);
            listaInsertar.Add(fechaIng);

            Conexion.EjecutarOperacion("ProductosInsert", listaInsertar, CommandType.StoredProcedure);

        }

        public void UpdateProducto(Producto oProducto)
        {
            List<SqlParameter> listaInsertar = new List<SqlParameter>();

            SqlParameter codigo = new SqlParameter("@P_CodigoProducto", oProducto.CodigoProducto);
            SqlParameter nombre = new SqlParameter("@P_NombreProducto", oProducto.NombreProducto);
            SqlParameter preciounit = new SqlParameter("@P_DireccionProducto", oProducto.PrecioUnitario);
            SqlParameter fechaIng = new SqlParameter("@P_FechaIngreso", oProducto.FechaIngreso);

            listaInsertar.Add(codigo);
            listaInsertar.Add(nombre);
            listaInsertar.Add(preciounit);
            listaInsertar.Add(fechaIng);

            Conexion.EjecutarOperacion("ProductosUpdate", listaInsertar, CommandType.StoredProcedure);
        }

        public void DeleteProducto(Producto oProducto)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            SqlParameter codigo = new SqlParameter("@P_IdProducto", oProducto.IdProducto);

            lista.Add(codigo);

            Conexion.EjecutarOperacion("ProductosDelete", lista, CommandType.StoredProcedure);
        }
    }
}
