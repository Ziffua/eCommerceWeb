using eCommerceWeb.Data.Base;
using eCommerceWeb.Data.Interfaces;
using eCommerceWeb.Models;

namespace eCommerceWeb.Data.Services
{
    public class BrandService : EntityBaseRepository<Brand>, IBrandService
    {
        public BrandService(AppDbContext context):base(context)
        {
            
        }
    }
}
