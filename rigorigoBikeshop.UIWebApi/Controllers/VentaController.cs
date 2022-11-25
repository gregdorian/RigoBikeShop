using Microsoft.AspNetCore.Mvc;
using System.Data; 

using RigoBikeshop.Domain.Core;
using RigoBikeshop.Domain.Entities;


namespace RigoBikeshop.UIWebApi.Controllers
{
    [ApiController]
    [Route("api/venta")]
    public class VentaController: ControllerBase
    {
        public VentaController()
        {

        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return Venta.ListarCliente();
        }
    }
}