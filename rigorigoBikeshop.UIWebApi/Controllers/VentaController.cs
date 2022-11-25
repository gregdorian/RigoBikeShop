namespace RigoBikeshop.UIWebApi.Controllers
{
    [ApiController]
using Microsoft.AspNetCore.Mvc;
using RigoBikeshop.Domain;
using RigoBikeshop.Domain.Entities;
using System.Data;
    
    [ApiController]
    [Route("api/venta")]
    public class VentaController: ControllerBase
    {
        public VentaController()
        {

        }

        [HttpGet]
        public ActionResult<IEnumerable<Venta>> Get()
        {
            return Venta.ListarCliente();
        }
    }
}