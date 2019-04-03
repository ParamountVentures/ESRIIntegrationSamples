using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TestEsri.Models;

namespace TestEsri.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _config;

        public HomeController(IConfiguration config)
        {
            this._config = config;
        }

        public IActionResult Index()
        {
            ViewBag.AppId = _config.GetValue<string>("EsriAppId");

            var layers = new List<string>();
            var config_layers = _config.GetSection("Layers").Get<string[]>();

            foreach (string layer in config_layers)
            {
                layers.Add(layer);
            }

            ViewBag.Layers = layers;

            return View();
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
