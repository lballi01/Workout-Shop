using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Workout_Shop.Data;

namespace Workout_Shop.Controllers
{
    public class WorkoutController : Controller
    {
        private readonly ApplicationDBContext _dbContext;

        public WorkoutController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var allWorkouts = _dbContext.Workouts.Include(n => n.Gyms).ToList();
            return View(allWorkouts);
        }
    }
}
