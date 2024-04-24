using System.ComponentModel.DataAnnotations;

namespace Workout_Shop.Models.Entites
{
    public class Gyms
    //This is the type of GYM i.e home, outdoors, Gym
    {
        [Key]
        public int GymId { get; set; }
        public string ?Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }

        public List<Workout> Workouts { get; set; }

    }
}
