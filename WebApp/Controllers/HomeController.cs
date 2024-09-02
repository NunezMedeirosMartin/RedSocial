using Microsoft.AspNetCore.Mvc;
using Obligatorio;
using System.Diagnostics;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        Sistema s = Sistema.GetInstancia();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            int? lid = HttpContext.Session.GetInt32("LogueadoID");
            if (lid != null)
            {
                ViewBag.Bienvenida = "GRACIAS POR INICIAR SESIÓN. NOS CENTRAMOS EN CONECTAR A NUESTROS USUARIOS Y PODER BRINDARLES UNA BUENA EXPERIENCIA. LE SOLICITAMOS QUE PUBLIQUE SIENDO RESPETUOSO/A. DISFRUTE DE LA APLICACIÓN.";
            }
            else
            {
                ViewBag.Bienvenida = "DEBE INICIAR SESIÓN.";
            }
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