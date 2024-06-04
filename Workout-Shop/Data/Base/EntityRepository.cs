using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using Workout_Shop.Data.Base.Interface;
using Workout_Shop.Models.Entites;

namespace Workout_Shop.Data.Base
{
    public class EntityRepository<T> : IEntityRepo<T> where T : class, IEntityBase, new()
    {
        private readonly ApplicationDBContext _dbContext;

        public EntityRepository(ApplicationDBContext context)
        {
            _dbContext = context;
        }

        public async Task AddAsync(T entity) {

            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
                
                }
            
        

        public async Task DeleteAsync(int id)

        {
            var entity = await _dbContext.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
            EntityEntry entityEntry = _dbContext.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;

            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync() =>  await _dbContext.Set<T>().ToListAsync();

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id) => await _dbContext.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
         
        

        public async Task UpdateAsync(int id, T entity)
        {
            EntityEntry entityEntry = _dbContext.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();

        }
    }
}
