using System.ComponentModel.DataAnnotations;

namespace Workout_Shop.Models.Entites
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }

        public Plan Plan { get; set; }

        public int Amount { get; set; }

        public string ShoppingCartId { get; set; }

    }
}
