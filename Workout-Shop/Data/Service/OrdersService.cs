using Microsoft.EntityFrameworkCore;
using System;
using Workout_Shop.Data.Service.IService;
using Workout_Shop.Models.Entites;

namespace Workout_Shop.Data.Service
{
    public class OrdersService: IOrderService
    {
        private readonly ApplicationDBContext _context;
        public OrdersService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole)
        {
            var orders = await _context.Orders.Include(n => n.OrderItems).ThenInclude(n => n.Plan).Where(n => n.UserId == userId).ToListAsync();

            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAddress
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    PlanId = item.Plan.Id,
                    OrderId = order.Id,
                    Price = item.Plan.Price
                };
                await _context.OrderItems.AddAsync(orderItem);
            }
            await _context.SaveChangesAsync();
        }


    }
}
