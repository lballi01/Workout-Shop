using Microsoft.AspNetCore.Mvc;
using Workout_Shop.Data;

namespace Workout_Shop.Controllers
{
    public class GymsController : Controller
    {
        private readonly ApplicationDBContext _dbContext;

        public GymsController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IActionResult Index()
        {
            var data = _dbContext.Gyms.ToList();
            return View(data);
        }
    }
}
