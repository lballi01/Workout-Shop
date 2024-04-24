using Microsoft.AspNetCore.Mvc;
using Workout_Shop.Data;

namespace Workout_Shop.Controllers
{
    public class MainInstructorController : Controller
    {
        private readonly ApplicationDBContext _dbContext;

        public MainInstructorController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var data = _dbContext.MainInstructors.ToList();

            return View(data);
        }
    }
}
