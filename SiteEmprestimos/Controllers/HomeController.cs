using Microsoft.AspNetCore.Mvc;
using SiteEmprestimos.Models;
using System.Diagnostics;

namespace SiteEmprestimos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            bool isDarkMode = false;
            if (Request.Cookies.TryGetValue("darkMode", out var darkModeValue))
            {
                bool.TryParse(darkModeValue, out isDarkMode);
            }

            ViewBag.isDarkMode = isDarkMode;
            
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