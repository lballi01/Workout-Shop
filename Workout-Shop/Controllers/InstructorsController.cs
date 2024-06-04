using Microsoft.AspNetCore.Mvc;
using Workout_Shop.Data;
using Workout_Shop.Data.Service.IService;
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

            return RedirectToAction(nameof(Index));
        }


        
        public async Task<IActionResult> Details (int id)
        {
            var InstructorDetails =await _instructorService.GetByIdAsync(id);

            if(InstructorDetails == null) {

                return View("NotFound");
            }

             return View(InstructorDetails);


        }

        //Get : Actors/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var instructorDetails = await _instructorService.GetByIdAsync(id);

            if (instructorDetails == null)
            {

                return View("NotFound");
            }

            return View(instructorDetails);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                return View(instructor);
            }

            await _instructorService.UpdateAsync(id, instructor);

            return RedirectToAction(nameof(Index));
        }


        //Get : Actors/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var instructorDetails = await _instructorService.GetByIdAsync(id);

            if (instructorDetails == null)
            {

                return View("NotFound");
            }

            return View(instructorDetails);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instructorDetails = await _instructorService.GetByIdAsync(id);
            if (instructorDetails == null)
            {

                return View("NotFound");
            }

            await _instructorService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

    }
}
