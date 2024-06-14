using eCommerceWeb.Data.Base;
using eCommerceWeb.Data.Interfaces;
using eCommerceWeb.Models;

namespace eCommerceWeb.Data.Services
{
    public class ProductService:EntityBaseRepository<Product>,IProductService
    {
        public ProductService(AppDbContext contex):base(contex)
        {
            
        }
    }
}
