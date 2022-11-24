
using System.Data;

using RigoBikeshop.Infraestructure.Data;
using RigoBikeshop.Domain.Entities;

namespace Domain.core
{
    public class RegistrarProductos
    {


        public static DataTable ConsultarProductos()
        {
            DataTable dtConsultaProductos;

            dtConsultaProductos = ProductoPersistence.GetAllProductos();


            return dtConsultaProductos;
        }

        public void CreateFacturaEncabezado(Producto oProducto)
        {
            try
            {
                ProductoPersistence.CreateProducto(oProducto);
            }
            catch (Exception ex)
            {
                //colocar mensaje de error si no cumple validaciones
                throw new Exception(ex.Message);
            }

        }

        public void UpdateFacturaEncabezado(Producto oProducto)
        {
            try
            {
                ProductoPersistence.UpdateProducto(oProducto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteFacturaEncabezado(Producto oProducto)
        {
            try
            {
                ProductoPersistence.DeleteProducto(oProducto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
