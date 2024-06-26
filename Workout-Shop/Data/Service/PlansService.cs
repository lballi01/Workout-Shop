using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System.Numerics;
using Workout_Shop.Data.Base;
using Workout_Shop.Data.Service.IService;
using Workout_Shop.Models;
using Workout_Shop.Models.Entites;
using Workout_Shop.Models.Relationships;
using Workout_Shop.Models.ViewModel;

namespace Workout_Shop.Data.Service
{
    public class PlansService: EntityRepository<Plan>, IPlansService
    {
        private readonly ApplicationDBContext _context;

        public PlansService(ApplicationDBContext context) : base(context)
        {

            _context = context;

        }

        public async Task AddCountAsync(int id)
        {
            var plan = await _context.Plans.FirstOrDefaultAsync(p => p.Id == id);

            if (plan != null)
            {
                plan.count++;
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddNewPlanAsync(PlanViewModel data)
        {
            var newPlan = new Plan()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                WorkoutCategory = data.WorkoutCategory,
                GymId = data.GymId,
                MainInstructorId = data.MainInstructorId,
                count = 0

            };

            await _context.Plans.AddAsync(newPlan);
            await _context.SaveChangesAsync();


            foreach (var InstructorId in data.InstructorId)
            {
                var newInstructor = new Instructor_Plan()
                {
                    PlanId = newPlan.Id,
                    InstructorId = InstructorId
                };

                await _context.Instructor_Plans.AddAsync(newInstructor);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<PlanDropdownViewModel> GetNewPlanDropdownValues()
        {
            var response = new PlanDropdownViewModel()
            {
                Instructors = await _context.Instructors.OrderBy(n => n.FullName).ToListAsync(),
                Gyms = await _context.Gyms.OrderBy(n => n.Name).ToListAsync(),
                MainInstructors = await _context.MainInstructors.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;
        }

        public async Task<Plan> GetPlanByIdAsync(int id)
        {
            var planDetails = await _context.Plans
                .Include(g => g.Gyms)
                .Include(m => m.MainInstructor)
                .Include(ip => ip.Instructor_Plan).ThenInclude(i => i.Instructor)
                .FirstOrDefaultAsync(n => n.Id == id);

            return planDetails;
        }

        public async Task UpdateNewPlanAsync(PlanViewModel data)
        {

            var dbPlan = await _context.Plans.FirstOrDefaultAsync(n => n.Id == data.Id);

            if(dbPlan != null)
            {

                dbPlan.Name = data.Name;
                dbPlan.Description = data.Description;
                dbPlan.Price = data.Price;
                dbPlan.ImageURL = data.ImageURL;
                dbPlan.StartDate = data.StartDate;
                dbPlan.EndDate = data.EndDate;
                dbPlan.WorkoutCategory = data.WorkoutCategory;
                dbPlan.GymId = data.GymId;
                dbPlan.MainInstructorId = data.MainInstructorId;

                             
                await _context.SaveChangesAsync();
            }

            var existingInstructorsDb = _context.Instructor_Plans.Where(i => i.InstructorId == data.Id).ToList();

            _context.Instructor_Plans.RemoveRange(existingInstructorsDb);
            await _context.SaveChangesAsync();

            foreach (var InstructorId in data.InstructorId)
            {
                var newInstructorMovie = new Instructor_Plan()
                {
                    PlanId = data.Id,
                    InstructorId = InstructorId
                };

                await _context.Instructor_Plans.AddAsync(newInstructorMovie);
            }

            await _context.SaveChangesAsync();
        }
    }
}
