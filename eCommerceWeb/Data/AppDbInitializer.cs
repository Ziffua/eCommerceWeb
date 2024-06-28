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
                            Description = "Dijital fotoğraf makineleri, lensler, kameralar",
                            LogoUrl="https://logowik.com/content/uploads/images/t_canon-black-wordmark1233.logowik.com.webp",                            
                        },
                        new Brand()
                        {
                            Name="Nike",
                            Description = "Kaliteli spor giyim ve ekipmanları. Just Do It",
                            LogoUrl="https://i.pinimg.com/736x/67/62/e2/6762e29e0f1357c3df379aaf978b52f5.jpg",
                        },
                        new Brand()
                        {
                            Name="Asus",
                            Description = "Yüksek kalite bilgisayarlar, laptoplar ve bilgisayar parçaları",
                            LogoUrl="https://logowik.com/content/uploads/images/424_asus.jpg",
                        },
                        new Brand()
                        {
                            Name="Yataş",
                            Description = "Uyku malzemeleri",
                            LogoUrl="https://mir-s3-cdn-cf.behance.net/projects/404/436b1741754895.Y3JvcCw1MjksNDE0LDExMyww.png",
                        },
                        new Brand()
                        {
                            Name="Dove",
                            Description = "Sabun, şampuan, krem ve diğer bakım ürünleri",
                            LogoUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQmgEtFUT_9grrJAxw1w326ZlUFmK7_yDwnTA&s",
                        },
                        new Brand()
                        {
                            Name="İş Bankası Yayınları",
                            Description = "Türkiye İş Bankası Kültür Yayınları kitapları...",
                            LogoUrl="https://img.kitapyurdu.com/v1/getImage/fn:4824728/wi:200/wh:aea1d3367",
                        },
                        new Brand()
                        {
                            Name="Dummy Marka",
                            Description = "Her türlü ürünü üreten ve satan genel bir marka",
                            LogoUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSbJo9WzggEITQH9jWp56cbBt2kg3qL_gHsHjRahPE-MvjtTmTJLbHOUHtFDWC0HZWkoTY&usqp=CAU"
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
                            Name = "TeknoShop",
                            About = "Teknoloji, hobi, ev ve bahçe malzemeleri",
                            PictureUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQaRGVIBn5mrbmtPP9EKncUC-5gIXV6ksObFw&s"
                        },
                        new Shop()
                        {
                            Name = "Düxan",
                            About = "A'dan Z'ye her şey burada! Düxan. Muazzam Fikirler...",
                            PictureUrl = "https://seeklogo.com/images/M/muazzam-fikirler-dukkani-logo-A674FD7B9A-seeklogo.com.gif"
                        },
                        new Shop()
                        {
                            Name = "Dummy Shop",
                            About = "Dummy Shop hakkında bilgisi",
                            PictureUrl = "https://www.shutterstock.com/image-vector/modern-vector-graphic-cubes-colorful-260nw-1960184035.jpg"
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
                            Name = "Ahşap Satranç",
                            Details = "Vakit geçirmek için güzel bir aktivite",
                            Price = 450,
                            Quantity = 80,
                            PictureUrl = "https://www.kaplantis.com/star-satranc-takimi-29x29-cm-satranc-star-oyun-167314-19-B.jpg",
                            Category = Enums.ProductCategory.Hobby,
                            BrandId = 7,
                            ShopId = 2
                        },new Product()
                        {
                            Name = "ROG Strix G16 Laptop",
                            Details = "Asus ROG Strix G16 G614JV-N3110 Intel Core i7 13650HX 16GB 512GB SSD RTX4060 Freedos 16\" WUXGA 165Hz Gaming Laptop",
                            Price = 50000,
                            Quantity = 20,
                            PictureUrl = "https://productimages.hepsiburada.net/s/373/550/110000390555317.jpg/format:webp",
                            Category = Enums.ProductCategory.Electironic,
                            BrandId = 3,
                            ShopId = 1
                        },new Product()
                        {
                            Name = "EOS 2000D DSLR Fotoğraf Makinesi",
                            Details = "Canon EOS 2000D 18-55MM DC III DSLR Dijital Fotoğraf Makinesi. 24 megapiksel EOS 2000 D ile düşük ışık koşulları olsa bile zahmetsiz bir şekilde DSLR kalitesinde fotoğraflar çekmeniz mümkündür. Sinematik full HD filmler çekmek için bile bu makineyi kullanabilirsiniz. İsterseniz çekimlerinizi yaptıktan sonra  NFC ve Wifi aracılığıyla uzaktan paylaşım yapabilirsiniz.",
                            Price = 16500,
                            Quantity = 35,
                            PictureUrl = "https://productimages.hepsiburada.net/s/777/550/110000643901391.jpg/format:webp",
                            Category = Enums.ProductCategory.Electironic,
                            BrandId = 1,
                            ShopId = 1
                        },new Product()
                        {
                            Name = "Air Force 1",
                            Details = "Air Force 1 beyaz spor ayakkabı. Bu model klasik basketbol havasını tüy kadar hafif yapıyla bir araya getiriyor",
                            Price = 4200,
                            Quantity = 100,
                            PictureUrl = "https://static.nike.com/a/images/t_PDP_1728_v1/f_auto,q_auto:eco/eckrubea0rzraob24xzf/air-force-1-flyknit-2-ayakkab%C4%B1-DDsg2r.png",
                            Category = Enums.ProductCategory.Fashion,
                            BrandId = 2,
                            ShopId = 3
                        },new Product()
                        {
                            Name = "Beyaz Şık Yastık",
                            Details = "Yataş Bedding DACRON® HOLLOFIL® ALLERBAN® Yastık 580 gr. (50x70 cm) Teknik Özellikler & Boyutlar: Ebat: 50x70 cm. Elastiki, hafif, gözenekli mikrofiber dolgu maddesiyle maksimum kabarıklık ve olağanüstü yumuşaklık sağlar.",
                            Price = 250,
                            Quantity = 75,
                            PictureUrl = "https://productimages.hepsiburada.net/s/27/1500/10182721929266.jpg",
                            Category = Enums.ProductCategory.Home,
                            BrandId = 4,
                            ShopId = 2
                        },new Product()
                        {
                            Name = "Saç Bakım Şampuanı",
                            Details = "Yoğun Onarıcı Yıpranmış Saçlar İçin 400 ml",
                            Price = 124,
                            Quantity = 50,
                            PictureUrl = "https://www.watsons.com.tr/medias/sys_master/prd-images/h4e/h63/9913168298014/prd-side-172788_365x385/prd-side-172788-365x385.jpg",
                            Category = Enums.ProductCategory.Selfcare,
                            BrandId = 5,
                            ShopId = 2
                        },new Product()
                        {
                            Name = "Kendime Düşünceler",
                            Details = "Yazar: Marcus Aurelius | Çevirmen: Yunus Emre Ceren | Orijinal Dili: Yunanca | Orijinal Adı: Ta Eis Heaton | İlk Baskı Yılı: 2018",
                            Price = 32,
                            Quantity = 28,
                            PictureUrl = "https://static.ticimax.cloud/30117/uploads/urunresimleri/buyuk/is-bankasi-kultur-yayinlari-kendime-du-e-bed0.jpg",
                            Category = Enums.ProductCategory.Book,
                            BrandId = 6,
                            ShopId = 3
                        },new Product()
                        {
                            Name = "Monitör",
                            Details = "VY249HF 23.8\" 1Ms 100Hz FHD IPS Gaming Monitör",
                            Price = 7650,
                            Quantity = 12,
                            PictureUrl = "https://reimg-teknosa-cloud-prod.mncdn.com/mnresize/600/600/productimage/785793000/785793000_0_MC/25a63c6f820745409fd9461c4d24a55d.jpg",
                            Category = Enums.ProductCategory.Electironic,
                            BrandId = 3,
                            ShopId = 1
                        },new Product()
                        {
                            Name = "Mürekkepli Yazıcı",
                            Details = "Olağanüstü sonuçlar üreten, ev kullanımına yönelik kompakt Hepsi Bir Arada yazıcı, tarayıcı ve fotokopi cihazı.",
                            Price = 1450,
                            Quantity = 60,
                            PictureUrl = "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/canon/thumb/v2-84313_large.jpg",
                            Category = Enums.ProductCategory.Electironic,
                            BrandId = 1,
                            ShopId = 1
                        },new Product()
                        {
                            Name = "Akıllı Telefon",
                            Details = "128GB Mor",
                            Price = 5500,
                            Quantity = 120,
                            PictureUrl = "https://cdn.evkur.com.tr/c/Product/66_d2p9tp.jpg",
                            Category = Enums.ProductCategory.Electironic,
                            BrandId = 7,
                            ShopId = 1
                        },
                    });
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUserAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

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

                string adminEmail = "admin@mail.com";
                var adminUser = userManager.FindByEmailAsync(adminEmail).Result;
                
                if(adminUser ==null)
                {
                    var newAdmin = new ApplicationUser()
                    {
                        FullName = "Admin",
                        UserName = "Admin",
                        Email = adminEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdmin, "123123");
                    await userManager.AddToRoleAsync(newAdmin, UserRoles.Admin);
                }

                string appUserEmail = "user@mail.com";
                var appUser = userManager.FindByEmailAsync(appUserEmail).Result;
                
                if(appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Ali Veli",
                        UserName = "userAli",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "123123");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }

                string sellerEmail = "seller@mail.com";
                var appSeller = userManager.FindByEmailAsync(sellerEmail).Result;
                var shop = context.Shops.FirstOrDefault(s => s.Id == 1);

                if (appSeller == null)
                {
                    var newSeller = new ApplicationUser()
                    {
                        FullName = "Mehmet Yılmaz",
                        UserName = "TeknoMemo",
                        Email = sellerEmail,
                        EmailConfirmed = true,
                    };

                    await userManager.CreateAsync(newSeller, "123123");
                    await userManager.AddToRoleAsync(newSeller, UserRoles.Seller);
                    shop.ApplicationUserId = userManager.FindByEmailAsync(sellerEmail).Result.Id;
                }


                string sellerEmail2 = "seller2@mail.com";
                var appSeller2 = userManager.FindByEmailAsync(sellerEmail2).Result;
                var shop2 = context.Shops.FirstOrDefault(s => s.Id == 2);

                if (appSeller2 == null)
                {
                    var newSeller = new ApplicationUser()
                    {
                        FullName = "Cenk Bey",
                        UserName = "Jenq",
                        Email = sellerEmail2,
                        EmailConfirmed = true,
                    };

                    await userManager.CreateAsync(newSeller, "123123");
                    await userManager.AddToRoleAsync(newSeller, UserRoles.Seller);
                    shop2.ApplicationUserId = userManager.FindByEmailAsync(sellerEmail2).Result.Id;
                }

                string sellerEmail3 = "seller3@mail.com";
                var appSeller3 = userManager.FindByEmailAsync(sellerEmail3).Result;
                var shop3 = context.Shops.FirstOrDefault(s => s.Id == 3);

                if (appSeller3 == null)
                {
                    var newSeller = new ApplicationUser()
                    {
                        FullName = "İsim Soyad",
                        UserName = "dummySeller",
                        Email = sellerEmail3,
                        EmailConfirmed = true,
                    };

                    await userManager.CreateAsync(newSeller, "123123");
                    await userManager.AddToRoleAsync(newSeller, UserRoles.Seller);
                    shop3.ApplicationUserId = userManager.FindByEmailAsync(sellerEmail3).Result.Id;
                    context.SaveChanges();
                }

            }
        }
    }
}
