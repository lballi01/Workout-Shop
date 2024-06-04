using Workout_Shop.Data.Base.Interface;
using Workout_Shop.Models.Entites;

namespace Workout_Shop.Data.Service.IService
{
    public interface IPlansService:IEntityRepo<Plan>
    {
        Task<Plan> GetPlanByIdAsync(int id);
    }
}
