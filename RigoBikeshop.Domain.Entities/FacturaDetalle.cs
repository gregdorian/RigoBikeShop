
namespace RigoBikeshop.Domain.Entities
{
    public class FacturaDetalle
    {

        public int IdFacturaDetalle { get; set; }

        public int IdFacturaEncabezado { get; set; }

        public int IdProducto { get; set; }

        public string CodigoProducto { get; set; }

        public string NombreProducto { get; set; }
        
        public int Cantidad { get; set; }

    }
}
