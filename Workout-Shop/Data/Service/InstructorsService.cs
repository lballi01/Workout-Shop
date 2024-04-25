using Microsoft.EntityFrameworkCore;
using Workout_Shop.Models.Entites;

namespace Workout_Shop.Data.Service
{
    public class InstructorsService : IInstructorService
    {
        private readonly ApplicationDBContext _dbContext;

        public InstructorsService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Instructor instructor)
        {
            _dbContext.Instructors.Add(instructor);
             await _dbContext.SaveChangesAsync();
        }

        public void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Instructor>> GetAllAsync()
        {
            var result = await _dbContext.Instructors.ToListAsync();
            return result;
        }

        public async Task <Instructor> GetByIdAsync(int id)
        {
            var result = await _dbContext.Instructors.FirstOrDefaultAsync(n => n.InstructorId == id);
            return result;
        }

        public Instructor UpdateAsync(int id, Instructor newInstructor)
        {
            throw new NotImplementedException();
        }
    }
}
