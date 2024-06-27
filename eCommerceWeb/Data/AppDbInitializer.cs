using eCommerceWeb.Data.Static;
using eCommerceWeb.Models;
using Microsoft.AspNetCore.Identity;
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

                if(!context.Shops.Any())
                {
                    context.Shops.AddRange(new List<Shop>()
                    {
                        new Shop()
                        {
                            Name = "Film Maker",
                            About = "Everything about cameras and film making",
                            PictureUrl = "assets\\Images\\ShopImages\\shopLogo1.png"
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
                            ShopId = 1
                        }
                    });
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUserAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!roleManager.RoleExistsAsync(UserRoles.Admin).Result)
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                }
                if (!roleManager.RoleExistsAsync(UserRoles.User).Result)
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
                }
                if(!roleManager.RoleExistsAsync(UserRoles.Seller).Result)
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Seller));
                }

                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                string adminEmail = "admin@ecommerce.com";
                var adminUser = userManager.FindByEmailAsync(adminEmail).Result;
                
                if(adminUser ==null)
                {
                    var newAdmin = new ApplicationUser()
                    {
                        FullName = "Admin Ali",
                        UserName = "Admin",
                        Email = adminEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdmin, "123123");
                    await userManager.AddToRoleAsync(newAdmin, UserRoles.Admin);
                }

                string appUserEmail = "user@ecommerce.com";
                var appUser = userManager.FindByEmailAsync(appUserEmail).Result;
                
                if(appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Cenk Kardeş",
                        UserName = "JenqBoi",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "123123");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }

                string sellerEmail = "seller@ecommerce.com";
                var appSeller = userManager.FindByEmailAsync(sellerEmail).Result;

                if (appSeller == null)
                {
                    var newSeller = new ApplicationUser()
                    {
                        FullName = "Ahmet Bey",
                        UserName = "FilmMakerAhmet",
                        Email = sellerEmail,
                        EmailConfirmed = true,
                    };
                    await userManager.CreateAsync(newSeller, "123123");
                    await userManager.AddToRoleAsync(newSeller, UserRoles.User);
                }

            }
        }
    }
}
