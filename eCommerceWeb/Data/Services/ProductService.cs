using eCommerceWeb.Data.Base;
using eCommerceWeb.Data.Enums;
using eCommerceWeb.Data.Interfaces;
using eCommerceWeb.Migrations;
using eCommerceWeb.Models;
using eCommerceWeb.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace eCommerceWeb.Data.Services
{
    public class ProductService:EntityBaseRepository<Product>,IProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context):base(context)
        {
            _context = context;
        }

        public async Task AddNewProductAsync(NewProductVM data)
        {
            var newProduct = new Product()
            {
                Name = data.Name,
                Details = data.Details,
                PictureUrl = data.PictureUrl,
                Price = data.Price,
                Quantity = data.Quantity,
                ViewCount = 0,
                BrandId = data.BrandId,
                ShopId = data.ShopId,
                Category = data.Category
            };
            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();
        }

        public async Task<NewProductDropdownsVM> GetNewProductDropdownsValues()
        {
            var response = new NewProductDropdownsVM()
            {
                Brands = await _context.Brands.OrderBy(b => b.Name).ToListAsync()
            };
            return response;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var productData = _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Shop)
                .FirstOrDefault(p=>p.Id == id);
            return productData;
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(ProductCategory category)
        {
            var products = await _context.Products
                .Where(p=>p.Category == category)
                .Include (p=>p.Brand)
                .Include (p=>p.Shop).ToListAsync();
            return products;
        }

        public async Task UpdateProductAsync(NewProductVM data)
        {
            var dbProduct = _context.Products.FirstOrDefault(p=>p.Id==data.id);
            if (dbProduct != null)
            {
                dbProduct.Name= data.Name;
                dbProduct.Details = data.Details;
                dbProduct.PictureUrl = data.PictureUrl;
                dbProduct.Price = data.Price;
                dbProduct.Quantity = data.Quantity;
                dbProduct.BrandId = data.BrandId;
                dbProduct.ShopId = data.ShopId;
                dbProduct.Category = data.Category;

                await _context.SaveChangesAsync();
            }
        }
    }
}
