using System.ComponentModel.DataAnnotations;
using Workout_Shop.Models.Relationships;

namespace Workout_Shop.Models.Entites
{
    public class Instructor
    {
        [Key]
        public int InstructorId { get; set; }

        public string ProfilePicture { get; set; }

        public string FullName { get; set; }

        public string Biography { get; set; }

        //Relationships
        public List<Instructor_Workout> Instructor_Workout { get; set; }
    }
}
