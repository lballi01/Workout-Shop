using Microsoft.AspNetCore.Mvc;
using Workout_Shop.Data;
using Workout_Shop.Data.Service;
using Workout_Shop.Data.Service.IService;
using Workout_Shop.Models.Entites;

namespace Workout_Shop.Controllers
{
    public class GymsController : Controller
    {
        private readonly IGymsService _service;

        public GymsController(IGymsService service)
        {
            _service = service;
        }


        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo", "Name", "Description")] Gyms gyms)
        {
            if (ModelState.IsValid) { return View(gyms); }
            await _service.AddAsync(gyms);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Details(int id)
        {
            var data = await _service.GetByIdAsync(id);
            if (data == null)  return View("NotFound");
                return View(data);
        }


        public async Task<IActionResult> Edit(int id)
        {
            var gymDetails = await _service.GetByIdAsync(id);

            if (gymDetails == null)
            {

                return View("NotFound");
            }
            return View(gymDetails);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Logo, Name, Description")] Gyms gyms)
        {
            if (ModelState.IsValid)
            {
                return View(gyms);
            }
                await _service.UpdateAsync(id, gyms);
            return RedirectToAction(nameof(Index)); 
        }


        public async Task<IActionResult> Delete(int id)
        {
            var gymsDetails = await _service.GetByIdAsync(id);

            if (gymsDetails == null)
            {

                return View("NotFound");
            }

            return View(gymsDetails);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gymsDetails = await _service.GetByIdAsync(id);
            if (gymsDetails == null)
            {

                return View("NotFound");
            }

            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

    }
}