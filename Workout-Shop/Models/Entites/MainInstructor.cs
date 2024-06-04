using System.ComponentModel.DataAnnotations;
using Workout_Shop.Data.Base.Interface;

namespace Workout_Shop.Models.Entites
{
    /// <summary>
    /// Main Instructor
    /// </summary>
    public class MainInstructor: IEntityBase 

    {
        [Key]
        public int Id { get; set; }

        public string ProfilePicture { get; set; }
        [Required ( ErrorMessage = "Profile Picture is required")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Full Name is required")]
        public string Biography { get; set; }
        [Required(ErrorMessage = "Biography is required")]
        public List<Plan> Workouts { get; set; }
    }
}
