using Workout_Shop.Models.Entites;

namespace Workout_Shop.Models.Relationships
{
    public class Instructor_Workout
    {

        public int WorkoutId { get; set; }
        public Workout Workout { get; set; }
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
    }
}
