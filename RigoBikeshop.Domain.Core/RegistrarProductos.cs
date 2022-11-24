
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

            ProductoPersistence ProducPer = new ProductoPersistence();

            dtConsultaProductos = ProducPer.GetAllProductos();

            //List<DataRow> lstProductos = dtConsultaProductos.AsEnumerable().ToList();

            return dtConsultaProductos;
        }

        public void CreateFacturaEncabezado(Producto oProducto)
        {
            try
            {
                ProductoPersistence ProducPer = new ProductoPersistence();
                ProducPer.CreateProducto(oProducto);
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
                ProductoPersistence ProducPer = new ProductoPersistence();
                ProducPer.UpdateProducto(oProducto);
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
                ProductoPersistence ProducPer = new ProductoPersistence();
                ProducPer.DeleteProducto(oProducto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
