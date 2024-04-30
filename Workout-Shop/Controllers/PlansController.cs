using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Workout_Shop.Data;

namespace Workout_Shop.Controllers
{
    public class PlansController : Controller
    {
        private readonly ApplicationDBContext _dbContext;

        public PlansController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var allPlans = _dbContext.Plans.Include(n => n.Gyms).ToList();
            return View(allPlans);
        }
    }
}
