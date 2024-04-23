using System.ComponentModel.DataAnnotations;

namespace Workout_Shop.Models.Entites
{
    /// <summary>
    /// Main Instructor
    /// </summary>
    public class Creator

    {
        [Key]
        public int MainInstructorId { get; set; }

        public string ProfilePicture { get; set; }

        public string FullName { get; set; }

        public string Biography { get; set; }

        public List<Workout> Workouts { get; set; }
    }
}
