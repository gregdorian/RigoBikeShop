
namespace RigoBikeshop.Domain.Entities
{
    public class FacturaEncabezado
    {

        public int IdEncabezado { get; set; }

        public int IdCliente { get; set; }

        public string NumeroFactura { get; set; }

        public decimal Total { get; set; }

        public DateTime FechaFactura { get; set; }

    }
}
