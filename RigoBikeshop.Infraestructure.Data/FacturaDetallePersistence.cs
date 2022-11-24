using Microsoft.Data.SqlClient;
using System.Data;

using RigoBikeshop.Domain.Entities;

namespace RigoBikeshop.Infraestructure.Data
{
    public static class FacturaDetallePersistence
    {
       
   //********** creacion de una linea en el detalle ******************
        public static void CreateFacturaDetalle(FacturaDetalle oFacturaDetalle, int idEncabezado)
        {
  
                List<SqlParameter> ListaDetalle = new List<SqlParameter>();

                oFacturaDetalle.IdFacturaEncabezado = idEncabezado;

                SqlParameter IdFacEnc = new SqlParameter("@P_IdFacturaEncabezado", oFacturaDetalle.IdFacturaEncabezado);
                SqlParameter IdProd = new SqlParameter("@P_IdProducto", oFacturaDetalle.IdProducto);
                SqlParameter CodigoProducto = new SqlParameter("@P_CodigoProducto", oFacturaDetalle.CodigoProducto);
                SqlParameter NombreProducto = new SqlParameter("@P_NombreProducto", oFacturaDetalle.NombreProducto);
                SqlParameter cantidad = new SqlParameter("@P_cantidad", oFacturaDetalle.Cantidad);

                ListaDetalle.Add(IdFacEnc);
                ListaDetalle.Add(IdProd);
                ListaDetalle.Add(CodigoProducto);
                ListaDetalle.Add(NombreProducto);
                ListaDetalle.Add(cantidad);


                Conexion.EjecutarOperacion("FacturaDetalleInsert", ListaDetalle, CommandType.StoredProcedure);
  
            }

        
   //********** Actualizacion de una linea en el detalle ******************
        public static void UpdateFacturaDetalle(FacturaDetalle oFacturaDetalle, int idEncabezado)
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
}
