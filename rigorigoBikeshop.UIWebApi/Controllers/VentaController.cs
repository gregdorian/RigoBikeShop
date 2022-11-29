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
        //[Produces("application/json")]
        public IActionResult GetCliente()
        {
            return Ok(Venta.ListarCliente());
        }

        [HttpGet("~/productos")]
        //[Produces("application/json")]
        public IEnumerable<Producto> GetProducto()
        {

            var resp = Venta.ListarProducto();
            return resp;
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