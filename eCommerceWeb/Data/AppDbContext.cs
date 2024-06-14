using eCommerceWeb.Models;
using eCommerceWeb.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace eCommerceWeb.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Seller> Sellers { get; set;}
        public DbSet<NewProductVM> NewProduct { get; set; } = default!;


    }
}
