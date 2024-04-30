using Workout_Shop.Models.Entites;

namespace Workout_Shop.Models.Relationships
{
    public class Instructor_Plan
    {

        public int PlanId { get; set; }
        public Plan Plan { get; set; }
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
    }
}
