using eCommerceWeb.Data.Base;
using eCommerceWeb.Data.Enums;
using eCommerceWeb.Models;
using eCommerceWeb.ViewModels;

namespace eCommerceWeb.Data.Interfaces
{
    public interface IProductService : IEntityBaseRepository<Product>
    {
        Task<Product> GetProductByIdAsync(int id);
        Task AddNewProductAsync(NewProductVM data);
        Task UpdateProductAsync(NewProductVM data);
        Task<NewProductDropdownsVM> GetNewProductDropdownsValues();
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(ProductCategory category);

    }
}
