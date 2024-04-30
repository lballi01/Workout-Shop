using Microsoft.EntityFrameworkCore;
using Workout_Shop.Data.Base;
using Workout_Shop.Models.Entites;

namespace Workout_Shop.Data.Service
{
    public class InstructorsService : EntityRepository<Instructor> ,IInstructorService
    {
        private readonly ApplicationDBContext _dbContext;

        public InstructorsService(ApplicationDBContext dbContext) : base(dbContext) { }
       

    }
}
