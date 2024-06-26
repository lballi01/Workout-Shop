using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using Workout_Shop.Data;
using Workout_Shop.Data.Service.IService;
using Workout_Shop.Models;
using Workout_Shop.Models.Entites;
using Workout_Shop.Models.Relationships;
using Workout_Shop.Models.ViewModel;


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

        public async Task<IActionResult> Filter(string searchString)
        {
            var data = await _service.GetAllAsync(n => n.Gyms);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = data.Where(p => p.Name.Contains(searchString) || p.Description.Contains(searchString)).ToList();
                return View("Index",filteredResult);
            }
            return View("Index", data);
        }


        public async Task<IActionResult> Details(int id)
        {
            var planDetails = await _service.GetPlanByIdAsync(id);
            return View(planDetails);
        }

        public async Task<IActionResult> Create()
        {
            var planDropdownData = await _service.GetNewPlanDropdownValues();

            ViewBag.GymsId = new SelectList(planDropdownData.Gyms, "Id", "Name");
            ViewBag.MainInstructorId = new SelectList(planDropdownData.MainInstructors, "Id", "FullName");
            ViewBag.InstructorId = new SelectList(planDropdownData.Instructors, "Id", "FullName");

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Create(PlanViewModel plan)
        {
            if(!ModelState.IsValid)
            {
                var planDropdownData = await _service.GetNewPlanDropdownValues();

                ViewBag.GymsId = new SelectList(planDropdownData.Gyms, "Id", "Name");
                ViewBag.MainInstructorId = new SelectList(planDropdownData.MainInstructors, "Id", "FullName");
                ViewBag.InstructorId = new SelectList(planDropdownData.Instructors, "Id", "FullName");

                return View(plan);
            }

            await _service.AddNewPlanAsync(plan);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var planDetails = await _service.GetPlanByIdAsync(id);

            if(planDetails == null)  return View ("Not Found");

            var response = new PlanViewModel()
            {
                Id = planDetails.Id,
                Name = planDetails.Name,
                Price = planDetails.Price,
                Description = planDetails.Description,
                ImageURL = planDetails.ImageURL,
                StartDate = planDetails.StartDate,
                EndDate = planDetails.EndDate,
                WorkoutCategory = planDetails.WorkoutCategory,
                GymId = planDetails.GymId,
                MainInstructorId = planDetails.MainInstructorId,
                InstructorId = planDetails.Instructor_Plan.Select(n =>n.InstructorId).ToList(),
            };

            var planDropdownData = await _service.GetNewPlanDropdownValues();

            ViewBag.GymsId = new SelectList(planDropdownData.Gyms, "Id", "Name");
            ViewBag.MainInstructorId = new SelectList(planDropdownData.MainInstructors, "Id", "FullName");
            ViewBag.InstructorId = new SelectList(planDropdownData.Instructors, "Id", "FullName");

            return View(response);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PlanViewModel plan)
        {
            if (id != plan.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var planDropdownData = await _service.GetNewPlanDropdownValues();

                ViewBag.GymsId = new SelectList(planDropdownData.Gyms, "Id", "Name");
                ViewBag.MainInstructorId = new SelectList(planDropdownData.MainInstructors, "Id", "FullName");
                ViewBag.InstructorId = new SelectList(planDropdownData.Instructors, "Id", "FullName");

                return View(plan);
            }

            await _service.UpdateNewPlanAsync(plan);
            return RedirectToAction(nameof(Index));
        }

    }
}
