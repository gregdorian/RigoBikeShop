
namespace RigoBikeshop.Domain.Entities
{
    public class Producto
    {
        public int IdProducto { get; set; }

        public string CodigoProducto { get; set; }

        public string NombreProducto { get; set; }

        public decimal PrecioUnitario { get; set; }

        public DateTime FechaIngreso { get; set; }


    }
}
