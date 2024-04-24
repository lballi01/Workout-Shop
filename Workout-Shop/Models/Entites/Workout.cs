using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Workout_Shop.Data.Enums;
using Workout_Shop.Models.Relationships;

namespace Workout_Shop.Models.Entites
{
    public class Workout
    {
        [Key]
        public int WorkoutId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string ImageURL { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public WorkoutCategory WorkoutCategory { get; set; }

        //Relationship

        public List<Instructor_Workout> Instructor_Workout { get; set; }


        //Gym
        public int GymId { get; set; }
        [ForeignKey("GymId")]
        public Gyms Gyms { get; set; }

        //Main Instructor
        public int MainInstructorId { get; set; }
        [ForeignKey("MainInstructorId")]
        public MainInstructor MainInstructor { get; set; }

    }
}
