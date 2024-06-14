using eCommerceWeb.Data.Base;
using eCommerceWeb.Data.Interfaces;
using eCommerceWeb.Models;

namespace eCommerceWeb.Data.Services
{
    public class SellerService: EntityBaseRepository<Seller>, ISellerService
    {
        public SellerService(AppDbContext context):base(context)
        {
            
        }
    }
}
