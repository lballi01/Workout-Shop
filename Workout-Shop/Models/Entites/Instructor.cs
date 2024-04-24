using System.ComponentModel.DataAnnotations;
using Workout_Shop.Models.Relationships;

namespace Workout_Shop.Models.Entites
{
    public class Instructor
    {
        [Key]
        public int InstructorId { get; set; }

        public string ProfilePicture { get; set; }
        [Display (Name = "Profile Picture")]
        public string FullName { get; set; }
        [Display(Name = "Full Name")]
        public string Biography { get; set; }
        [Display(Name = "Biography")]

        //Relationships
        public List<Instructor_Workout> Instructor_Workout { get; set; }
    }
}
