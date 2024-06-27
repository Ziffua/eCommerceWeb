using eCommerceWeb.Models;

namespace eCommerceWeb.Data.Interfaces
{
    public interface IOrderService
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress);

        Task<List<Order>> GetOrdersByUserAsync(string userId, string userRole);
    }
}
