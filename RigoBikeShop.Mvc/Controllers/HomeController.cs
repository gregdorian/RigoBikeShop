using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RigoBikeshop.Domain.Entities;
using RigoBikeShop.Mvc.Models;
using System.Diagnostics;
using System.Text;

namespace RigoBikeShop.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        

 
        public HomeController(ILogger<HomeController> logger )
        {
            _logger = logger;

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddVenta(FacturaVentaDTO oVentaDto)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(oVentaDto), Encoding.UTF8, "application/json");
                string endpoint = "http://localhost:5294";
                using (var Response = await client.PostAsync(endpoint, content))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        TempData["Profile"] = JsonConvert.SerializeObject(oVentaDto);
                        return RedirectToAction("Index");
                    }
                    else if (Response.StatusCode == System.Net.HttpStatusCode.Conflict)
                    {
                        ModelState.Clear();
                        ModelState.AddModelError("Venta", "Venta ya se ha realizado");
                        return View();
                    }
                    else
                    {
                        return View();
                    }
                }
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}