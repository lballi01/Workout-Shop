using System.Linq.Expressions;
using Workout_Shop.Models.Entites;

namespace Workout_Shop.Data.Base.Interface
{
    public interface IEntityRepo<T> where T : class, IEntityBase,new()
    {

        Task<IEnumerable<T>> GetAllAsync();


        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);

        Task<T> GetByIdAsync(int id);


        Task AddAsync(T entity);

        Task UpdateAsync(int id, T entity);

        Task DeleteAsync(int id);

    }
}
