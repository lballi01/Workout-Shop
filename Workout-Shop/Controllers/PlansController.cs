using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Workout_Shop.Data;
using Workout_Shop.Data.Service.IService;

namespace Workout_Shop.Controllers
{
    public class PlansController : Controller
    {
        private readonly IPlansService _service;

        public PlansController(IPlansService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync(n => n.Gyms);
            return View(data);
        }

        public async Task<IActionResult> Details(int id)
        {
            var planDetails = await _service.GetPlanByIdAsync(id);
            return View(planDetails);
        }

        public IActionResult Create()
        {
            ViewData["welcome"] = "Welcome to our store";
            return View();
        }
    }
}
