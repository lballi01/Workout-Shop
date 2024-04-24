using Microsoft.AspNetCore.Mvc;
using Workout_Shop.Data;

namespace Workout_Shop.Controllers
{
    public class InstructorsController : Controller
    {
        private readonly ApplicationDBContext _dbContext;

        public InstructorsController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var data = _dbContext.Instructors.ToList();
            return View(data);
        }
    }
}
