using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using Workout_Shop.Data.Base;
using Workout_Shop.Data.Service.IService;
using Workout_Shop.Models.Entites;

namespace Workout_Shop.Data.Service
{
    public class PlansService: EntityRepository<Plan>, IPlansService
    {
        private readonly ApplicationDBContext _context;

        public PlansService(ApplicationDBContext context) : base(context)
        {

            _context = context;

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
    }
}
