using Workout_Shop.Data.Base;
using Workout_Shop.Data.Service.IService;
using Workout_Shop.Models.Entites;

namespace Workout_Shop.Data.Service
{
    public class MainInstrcutorService : EntityRepository<MainInstructor>, IMainInstrcutorsService
    {
        public MainInstrcutorService(ApplicationDBContext context) : base(context)
        {
            
        }
    }
}
