using Workout_Shop.Models.Entites;

namespace Workout_Shop.Data.Service
{
    public interface IInstructorService
    {
        Task<IEnumerable<Instructor>> GetAllAsync();

        Task<Instructor> GetByIdAsync(int id);


        Task AddAsync(Instructor instructor);

        Instructor UpdateAsync(int id, Instructor newInstructor);

        void DeleteAsync(int id);

    }
}
