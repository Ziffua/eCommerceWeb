using eCommerceWeb.Data;
using eCommerceWeb.Data.Interfaces;
using eCommerceWeb.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerceWeb.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _service;
        public ProductsController(IProductService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var productData= await _service.GetAllAsync(p => p.Seller, p => p.Brand);

            return View(productData);

        }
    }
}
