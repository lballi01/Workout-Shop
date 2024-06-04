using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Workout_Shop.Data.Base.Interface;
using Workout_Shop.Data.Enums;
using Workout_Shop.Models.Relationships;

namespace Workout_Shop.Models.Entites
{
    public class Plan:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string ImageURL { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public WorkoutCategory WorkoutCategory { get; set; }

        //Relationship

        public List<Instructor_Plan> Instructor_Plan { get; set; }


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
