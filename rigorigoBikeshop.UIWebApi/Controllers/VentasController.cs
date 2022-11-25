using Domain.core;
using Microsoft.AspNetCore.Mvc;
using RigoBikeshop.Domain;
using RigoBikeshop.Domain.Entities;
using System.Data;

namespace RigoBikeshop.UIWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        // GET: api/<VentasController>
        [HttpGet]
        public IList<DataRow> Get()
        {
            return Venta.ListarCliente();
        }

        // GET api/<VentasController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<VentasController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<VentasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VentasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
