using eCommerceWeb.Models;
using Microsoft.CodeAnalysis.Emit;

namespace eCommerceWeb.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder) 
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                if (!context.Brands.Any())
                {
                    context.Brands.AddRange(new List<Brand>() { 
                        new Brand()
                        {
                            Name="Canon",
                            Description = "high quality cameras",
                            LogoUrl="assets\\Images\\BrandLogos\\canonLogo.png",                            
                        },
                        new Brand()
                        {
                            Name="Nike",
                            Description = "high quality sport-wear",
                            LogoUrl="assets\\Images\\BrandLogos\\Nike-Logo.png",
                        }
                    });
                    context.SaveChanges();
                }

                if(!context.Sellers.Any())
                {
                    context.Sellers.AddRange(new List<Seller>()
                    {
                        new Seller()
                        {
                            Name = "Film Maker",
                            About = "Everything about cameras and film making",
                            PictureUrl = "assets\\Images\\SellerImages\\sellerLogo1.png"
                        }
                    });
                    context.SaveChanges();
                }

                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                    {
                        new Product()
                        {
                            Name = "Camera1",
                            Details = "Good performance for the price",
                            Price = 3000,
                            Quantity = 100,
                            PictureUrl = "assets\\Images\\ProductImages\\canonCam1.jpg",
                            Category = Enums.ProductCategory.Electironic,
                            BrandId = 1,
                            SellerId = 1
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
