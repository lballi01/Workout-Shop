using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Workout_Shop.Data.Cart;
using Workout_Shop.Data.Service;
using Workout_Shop.Data.Service.IService;
using Workout_Shop.Models.ViewModel;

namespace Workout_Shop.Controllers
{
    public class OrdersController : Controller
    {

        private readonly IPlansService _plansService;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrderService _ordersService;

        public OrdersController(IPlansService plansService, ShoppingCart shoppingCart, IOrderService ordersService)
        {
            _plansService = plansService;
            _shoppingCart = shoppingCart;
            _ordersService = ordersService;
        }

        public async Task<IActionResult> Index()
        {
            string userId = "";
            string userRole = "";

            var orders = await _ordersService.GetOrdersByUserIdAndRoleAsync(userId, userRole);
            return View(orders);
        }

        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartViewModel()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(response);
        }

        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            var item = await _plansService.GetPlanByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _plansService.GetPlanByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            var planIds = items.Select(n => n.Plan.Id).ToList();


            string userId = "";
            string userEmailAddress = "";

            foreach (var planId in planIds)
            {
            
                await _plansService.AddCountAsync(planId);
            }

            await _ordersService.StoreOrderAsync(items, userId, userEmailAddress);
            await _shoppingCart.ClearShoppingCartAsync();

            return View("OrderCompleted");
        }
    }
}
