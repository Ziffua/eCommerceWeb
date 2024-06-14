using eCommerceWeb.Data;
using eCommerceWeb.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerceWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _service;
        public ProductController(ProductService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            
            return View();

        }
    }
}
