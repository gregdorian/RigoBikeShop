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
                SqlParameter cantidad = new SqlParameter("@P_cantidad", oFacturaDetalle.Cantidad);

                ListaDetalle.Add(IdFacEnc);
                ListaDetalle.Add(IdProd);
                ListaDetalle.Add(cantidad);


                Conexion.EjecutarOperacion("FacturaDetalleInsert", ListaDetalle, CommandType.StoredProcedure);
  
            }

        
   //********** Actualizacion de una linea en el detalle ******************
        public static void UpdateFacturaDetalle(FacturaDetalle oFacturaDetalle, int idEncabezado)
        {

                List<SqlParameter> ListaDetalle = new List<SqlParameter>();

                SqlParameter IdFacEnc = new SqlParameter("@P_IdFacturaEncabezado", oFacturaDetalle.IdFacturaEncabezado);
                SqlParameter IdProd = new SqlParameter("@P_IdProducto", oFacturaDetalle.IdProducto);
                SqlParameter cantidad = new SqlParameter("@P_cantidad", oFacturaDetalle.Cantidad);

                ListaDetalle.Add(IdFacEnc);
                ListaDetalle.Add(IdProd);
                ListaDetalle.Add(cantidad);

                Conexion.EjecutarOperacion("FacturaDetalleUpdate", ListaDetalle, CommandType.StoredProcedure);
        }


    }
}
