
namespace RigoBikeshop.Domain.Entities
{
    public class FacturaEncabezado
    {
        public FacturaEncabezado()
        {
           this.Lineas = new List<FacturaDetalle>();
        }
        public int IdEncabezado { get; set; }

        public int IdCliente { get; set; }

        public string NumeroFactura { get; set; }

        public string CodigoEmpresa { get; set; }

        public string CodigoCliente { get; set; }

        public decimal Total { get; set; }

        public DateTime FechaFactura { get; set; }

        public List<FacturaDetalle> Lineas { get; set; }

    }
}
