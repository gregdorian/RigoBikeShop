using Microsoft.AspNetCore.Mvc;
using System.Data; 

using RigoBikeshop.Domain.Core;
using RigoBikeshop.Domain.Entities;
using Newtonsoft.Json;

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
        [Produces("application/json")]
        public IActionResult GetCliente()
        {
            var resp = JsonConvert.DeserializeObject<List<Clientes>>(Venta.ListarCliente());
            return Ok(resp);
        }

        [HttpGet("~/productos")]
        [Produces("application/json")]
        public IActionResult GetProducto()
        {

            var resp = JsonConvert.DeserializeObject<List<Producto>>(Venta.ListarProducto());
            return Ok(resp);
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