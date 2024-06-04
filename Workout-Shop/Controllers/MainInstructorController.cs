using Microsoft.AspNetCore.Mvc;
using Workout_Shop.Data;
using Workout_Shop.Data.Service.IService;
using Workout_Shop.Models.Entites;

namespace Workout_Shop.Controllers
{
    public class MainInstructorController : Controller
    {
        private readonly IMainInstrcutorsService _service;

        public MainInstructorController(IMainInstrcutorsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allInstructors = await _service.GetAllAsync();

            return View(allInstructors);
        }

        //GET: producers/details/1
        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);

            if (producerDetails == null) {
                return View("NotFound");
                    }
            return View(producerDetails);
        }

        //GET: MainInstructors/Create
        public IActionResult Create ()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePicture, FullName, Biography")] MainInstructor mainInstructor)
        {
            if (ModelState.IsValid) { return View(mainInstructor); }
            await _service.AddAsync(mainInstructor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if(producerDetails == null)  return View("Not Found");
            return View(producerDetails);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, ProfilePicture, FullName, Biography")] MainInstructor mainInstructor)
        {
            if (ModelState.IsValid) { return View(mainInstructor); }

            if (id == mainInstructor.Id)
            {
                await _service.UpdateAsync(id, mainInstructor);
                return RedirectToAction(nameof(Index));
            }

            return View(mainInstructor);
            
        }

        
        public async Task<IActionResult> Delete(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("Not Found");
            return View(producerDetails);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id )
        {

            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("Not Found");


            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
