using Workout_Shop.Data.Base;
using Workout_Shop.Data.Service.IService;
using Workout_Shop.Models.Entites;

namespace Workout_Shop.Data.Service
{
    public class GymsService:EntityRepository<Gyms>, IGymsService
    {
        public GymsService(ApplicationDBContext context) : base(context)
        {
            
        }
    }
}
