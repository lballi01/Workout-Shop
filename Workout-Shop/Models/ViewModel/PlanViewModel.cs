using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Workout_Shop.Data.Base.Interface;
using Workout_Shop.Data.Enums;
using Workout_Shop.Models.Relationships;

namespace Workout_Shop.Models
{
    public class PlanViewModel
    {

        [Required(ErrorMessage = "Name is required") ]
        [Display(Description = "Plan Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Descrption is required")]
        [Display(Description = "Plan Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Display(Description = "Plan Price")]
        public double Price { get; set; }

        public string ImageURL { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public WorkoutCategory WorkoutCategory { get; set; }

        //Relationship

        public List<int> InstructorId { get; set; }


        //Gym
        public int GymId { get; set; }
        

        //Main Instructor
        public int MainInstructorId { get; set; }
        public int Id { get; set; }
    }
}
