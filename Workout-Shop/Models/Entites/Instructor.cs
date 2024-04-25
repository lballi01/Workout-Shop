using System.ComponentModel.DataAnnotations;
using Workout_Shop.Models.Relationships;

namespace Workout_Shop.Models.Entites
{
    public class Instructor
    {
        [Key]
        public int InstructorId { get; set; }

        [Display(Name = "ProfilePicture")]
        [Required(ErrorMessage = "Profile Picture is Required")]
        public string ProfilePicture { get; set; }
        


        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is Required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 characters")]
        public string FullName { get; set; }
       

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Description is Required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 characters")]
        public string Biography { get; set; }
        

        //Relationships
        public List<Instructor_Workout> Instructor_Workout { get; set; }
    }
}
