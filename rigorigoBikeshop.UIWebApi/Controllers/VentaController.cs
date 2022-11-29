using Microsoft.AspNetCore.Mvc;
using System.Data; 

using RigoBikeshop.Domain.Core;
using RigoBikeshop.Domain.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NuGet.Common;

namespace RigoBikeshop.UIWebApi.Controllers
{
    [ApiController]
    [Route("api/venta")]
    public class VentaController: ControllerBase
    {
        public VentaController()
        {

        }

        [HttpGet("~/clientes")]
        public IEnumerable<Clientes> GetClientes()
        {
            
            return Venta.ListarCliente();
        }

        [HttpGet("~/productos")]
        public IEnumerable<Producto> GetProducto()
        {
;
            return Venta.ListarProducto();
        }


        [HttpPost]
        public void Post([FromBody] FacturaVentaDTO oVentaDto)
        {
            Venta.RegistrarFacturaVenta(oVentaDto);
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}