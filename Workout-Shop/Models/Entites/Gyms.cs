using System.ComponentModel.DataAnnotations;
using Workout_Shop.Data.Base.Interface;

namespace Workout_Shop.Models.Entites
{
    public class Gyms:IEntityBase  
    //This is the type of GYM i.e home, outdoors, Gym
    {
        [Key]
        public int Id { get; set; }
        public string ?Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        [Required]

        public List<Plan> Workouts { get; set; }

    }
}
