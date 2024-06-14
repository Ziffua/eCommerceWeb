using eCommerceWeb.Data;
using eCommerceWeb.Data.Interfaces;
using eCommerceWeb.Data.Services;
using Microsoft.EntityFrameworkCore;

namespace eCommerceWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //DbContex configuration. Get the connection between SQL Server and DbContext
            builder.Services.AddDbContext<Data.AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

            //Service configuration. Register the Model services and their related interfaces
            builder.Services.AddScoped<ISellerService, SellerService>();
            builder.Services.AddScoped<IBrandService, BrandService>();
            builder.Services.AddScoped<IProductService, ProductService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Sellers}/{action=Index}/{id?}");

            AppDbInitializer.Seed(app);

            app.Run();
        }
    }
}
