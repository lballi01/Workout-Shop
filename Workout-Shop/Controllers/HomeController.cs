using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Workout_Shop.Models;

namespace Workout_Shop.Controllers
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
            return View();
        }

        
    }
}
