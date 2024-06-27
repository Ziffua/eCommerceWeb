using eCommerceWeb.Data.Interfaces;
using eCommerceWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerceWeb.Data.Services
{
    public class OrderService : IOrderService
    {
        public readonly AppDbContext _context;
        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrdersByUserAsync(string userId, string userRole)
        {
            var orders = await _context.Orders
                .Include(o=>o.OrderItems)
                .ThenInclude(oi=>oi.Product)
                .Where(o=>o.UserId == userId)
                .ToListAsync();
            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        {
            //Master kayıt

            var order = new Order
            {
                UserId = userId,
                Email = userEmailAddress
            };

            await _context.Orders.AddAsync(order);

            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItem = new OrderItem
                {
                    Amount = item.Amount,
                    ProductId = item.Product.Id,
                    Price = item.Product.Price,
                    OrderId = order.Id               
                };

                await _context.OrderItems.AddAsync(orderItem);
            }

            await _context.SaveChangesAsync();
        }

    }
}
