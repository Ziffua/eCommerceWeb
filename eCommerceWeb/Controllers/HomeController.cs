using eCommerceWeb.Data;
using eCommerceWeb.Data.Enums;
using eCommerceWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace eCommerceWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var brands = _context.Brands
                .OrderBy(b=>b.Id)
                .Take(6).ToList();

            ViewBag.MostPopularProducts = _context.Products
                .OrderByDescending(p=>p.ViewCount)
                .Take(6)
                .ToList();
            ViewBag.PopularElectronics = _context.Products
                .Where(p => p.Category == ProductCategory.Electironic)
                .OrderByDescending(p => p.ViewCount)
                .Take(6)
                .ToList();
            ViewBag.PopularFashion = _context.Products
                .Where(p => p.Category == ProductCategory.Fashion)
                .OrderByDescending(p => p.ViewCount)
                .Take(6)
                .ToList();
            ViewBag.PopularHome = _context.Products
                .Where(p => p.Category == ProductCategory.Home)
                .OrderByDescending(p => p.ViewCount)
                .Take(6)
                .ToList();

            ViewBag.PopularBooks = _context.Products
                .Where(p => p.Category == ProductCategory.Book)
                .OrderByDescending(p => p.ViewCount)
                .Take(6)
                .ToList();

            ViewBag.PopularSelfcare = _context.Products
                .Where(p => p.Category == ProductCategory.Selfcare)
                .OrderByDescending(p => p.ViewCount)
                .Take(6)
                .ToList();

            ViewBag.PopularHobby = _context.Products
                .Where(p => p.Category == ProductCategory.Hobby)
                .OrderByDescending(p => p.ViewCount)
                .Take(6)
                .ToList();

            return View(brands);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
