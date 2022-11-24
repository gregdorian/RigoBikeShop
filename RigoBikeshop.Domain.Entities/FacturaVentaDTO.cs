using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RigoBikeshop.Domain.Entities
{
    public class FacturaVentaDTO
    {
        public FacturaVentaDTO()
        {
            this.Lineas = new List<FacturaDetalle>();
        }

        public int IdEncabezado { get; set; }

        public int IdDetalle { get; set; }

        public int IdCliente { get; set; }

        public string NumeroFactura { get; set; }

        public decimal Total { get; set; }

        public DateTime FechaFactura { get; set; }

        public List<FacturaDetalle> Lineas { get; set; }
    }
}
