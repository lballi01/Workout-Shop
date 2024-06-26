using Workout_Shop.Models.Entites;

namespace Workout_Shop.Models.ViewModel
{
    public class PlanDropdownViewModel
    {
        public PlanDropdownViewModel() {

            MainInstructors = new List<MainInstructor>();
            Gyms = new List<Gyms>();
            Instructors = new List<Instructor>();
        }

        public List<MainInstructor> MainInstructors { get; set; }
        public List<Gyms> Gyms { get; set; }
        public List<Instructor> Instructors { get; set; }
    }
}
