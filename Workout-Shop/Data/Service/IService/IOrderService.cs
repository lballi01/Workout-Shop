using Workout_Shop.Models.Entites;

namespace Workout_Shop.Data.Service.IService
{
    public interface IOrderService
    {

        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress);
        Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole);

    }
}
