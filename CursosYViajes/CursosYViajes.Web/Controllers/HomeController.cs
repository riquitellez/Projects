using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CursosYViajes.Web.Models;
using CursosYViajes.Servicios;
using System.Reflection;
using System.IO;

namespace CursosYViajes.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            _servicio = new HomeServicio();
        }
        private HomeServicio _servicio;
        public IActionResult Index()
        {           
            string jsonString = string.Empty;
            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream("CursosYViajes.Web.Json.home.json"))
            {
                using (var sr = new StreamReader(stream))
                {
                    jsonString = sr.ReadToEnd();
                }

            }

            var home = _servicio.ObtenerDatos(jsonString);
            return View(home);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
