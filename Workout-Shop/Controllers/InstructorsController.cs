using Microsoft.AspNetCore.Mvc;
using Workout_Shop.Data;
using Workout_Shop.Data.Service;
using Workout_Shop.Models.Entites;

namespace Workout_Shop.Controllers
{
    public class InstructorsController : Controller
    {
        private readonly IInstructorService _instructorService;

        public InstructorsController(IInstructorService instructorService)
        {
           _instructorService = instructorService;
        }
        
        public async Task<IActionResult> Index()
        {
            var data = await  _instructorService.GetAllAsync();
            return View(data);
        }



        public async Task<IActionResult> Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePicture,Biography")]Instructor instructor)
        {
            if(ModelState.IsValid)
            {
                return View(instructor);
            }

           await _instructorService.AddAsync(instructor);

            return Redirect(nameof(Index));
        }


        
        public async Task<IActionResult> Details (int id)
        {
            var InstructorDetails =await _instructorService.GetByIdAsync(id);

            if(InstructorDetails == null) {

                return View(Empty);
            }

             return View(InstructorDetails);


        }

    }
}
