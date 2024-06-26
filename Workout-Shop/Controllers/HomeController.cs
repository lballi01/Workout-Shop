using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Workout_Shop.Data.Service.IService;
using Workout_Shop.Models;

namespace Workout_Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPlansService _service;

      

        public HomeController(IPlansService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync(n => n.Gyms);
            return View(data);
        }


    }
}
