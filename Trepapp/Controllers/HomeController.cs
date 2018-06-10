using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trepapp.Models;

namespace Trepapp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [Authorize(Roles = "Admin")]
        public IActionResult Users()
        {
            ViewData["Message"] = "Página para administradores";

            return View();
        }
        
        public IActionResult Sectors()
        {
            ViewData["Message"] = "";

            return View();
        }
        
        public IActionResult Vias()
        {
            ViewData["Message"] = "";

            return View();
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

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
