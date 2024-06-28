using eCommerceWeb.Data.Cart;
using eCommerceWeb.Data.Interfaces;
using eCommerceWeb.Data.Services;
using eCommerceWeb.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceWeb.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IProductService _productService;
        private readonly ShoppingCart _shoppingCart;

        private readonly IOrderService _orderService;
        public OrdersController(IProductService productService, ShoppingCart shoppingCart, IOrderService orderService)
        {
            _productService = productService;
            _shoppingCart = shoppingCart;
            _orderService = orderService;

        }

        
        public async Task<IActionResult> Index()
        {
            string userId = "";
            string userRole = "";
            var orders = await _orderService.GetOrdersByUserAsync(userId, userRole);
            return View(orders);
        }

        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(response);
        }

        public async Task<RedirectToActionResult> AddItemToShoppingCart(int id)
        {
            var item = await _productService.GetProductByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }

            return RedirectToAction("ShoppingCart");
        }

        public async Task<RedirectToActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _productService.GetProductByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }

            return RedirectToAction("ShoppingCart");
        }

        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();

            string userId = "";
            string userEmailAddress = "";

            await _orderService.StoreOrderAsync(items, userId, userEmailAddress);

            await _shoppingCart.ClearShoppinCartAsync();

            return View("OrderCompleted");
        }
    }
}
