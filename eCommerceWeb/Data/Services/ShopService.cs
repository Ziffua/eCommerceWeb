using eCommerceWeb.Data.Base;
using eCommerceWeb.Data.Interfaces;
using eCommerceWeb.Models;

namespace eCommerceWeb.Data.Services
{
    public class ShopService: EntityBaseRepository<Shop>, IShopService
    {
        public ShopService(AppDbContext context):base(context)
        {
            
        }
    }
}
