using Workout_Shop.Data.Base.Interface;
using Workout_Shop.Models;
using Workout_Shop.Models.Entites;
using Workout_Shop.Models.ViewModel;

namespace Workout_Shop.Data.Service.IService
{
    public interface IPlansService:IEntityRepo<Plan>
    {
        Task<Plan> GetPlanByIdAsync(int id);

        Task<PlanDropdownViewModel> GetNewPlanDropdownValues();

        Task AddNewPlanAsync(PlanViewModel data);

        Task UpdateNewPlanAsync(PlanViewModel data);

        Task AddCountAsync(int id);
    }
}
