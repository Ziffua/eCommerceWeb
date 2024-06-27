using eCommerceWeb.Data;
using eCommerceWeb.Data.Enums;
using eCommerceWeb.Data.Interfaces;
using eCommerceWeb.Data.Services;
using eCommerceWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace eCommerceWeb.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _service;
        private readonly AppDbContext _context;
        public ProductsController(IProductService service, AppDbContext context)
        {
            _service = service;
            _context = context;
        }
        public async Task<IActionResult> Index(ProductCategory category)
        {
            if(category==0) // No Category filter
            {   
                var productData= await _service.GetAllAsync(p => p.Shop, p => p.Brand);
                return View(productData);
            }
            else // Filter by category
            {
                ViewBag.Category = category.ToString();
                var productData = await _service.GetProductsByCategoryAsync(category);
                return View(productData);
            }

        }

        public async Task<IActionResult> Details(int id)
        {
            var productDetails= await _service.GetProductByIdAsync(id);
            if (productDetails == null)
            {
                return View("NotFound");
            }
            productDetails.ViewCount++;
            await _service.UpdateAsync(productDetails);
            return View(productDetails);
        }

        public async Task<IActionResult> Create()
        {
            var productDropDownsData = await _service.GetNewProductDropdownsValues();

            ViewBag.Brands = new SelectList(productDropDownsData.Brands, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string userId, NewProductVM product)
        {

            if (!ModelState.IsValid)
            {
                var productDropDownsData = await _service.GetNewProductDropdownsValues();
                ViewBag.Brands = new SelectList(productDropDownsData.Brands, "Id", "Name");
                return View(product);
            }

            var shop = _context.Shops.FirstOrDefault(s=>s.ApplicationUserId == userId);
            product.ShopId = shop.Id;

            await _service.AddNewProductAsync(product);

            return RedirectToAction(nameof(Edit), "Shops", new {id=shop.Id});

        }
        public async Task<IActionResult> Edit(int id)
        {
            var productDetails = await _service.GetProductByIdAsync(id); 

            if (productDetails == null) return View("NotFound");

            var data = new NewProductVM()
            {
                id = productDetails.Id,
                Name = productDetails.Name,
                Details = productDetails.Details,
                PictureUrl = productDetails.PictureUrl,
                Price = productDetails.Price,
                Quantity = productDetails.Quantity,
                BrandId = productDetails.BrandId,
                ShopId = productDetails.ShopId,
                Category = productDetails.Category
            };

            var productDropDownsData = await _service.GetNewProductDropdownsValues();

            ViewBag.Brands = new SelectList(productDropDownsData.Brands, "Id", "Name");

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewProductVM product)
        {
            if (!ModelState.IsValid)
            {
                var productDropDownsData = await _service.GetNewProductDropdownsValues();

                ViewBag.Brands = new SelectList(productDropDownsData.Brands, "Id", "Name");

                return View(product);
            }

            await _service.UpdateProductAsync(product);

            return RedirectToAction(nameof(Details), new {Id = id});

        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var allProducts = await _service.GetAllAsync(p=>p.Brand, p=>p.Shop);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allProducts
                    .Where(p=>
                    p.Name.ToLower().Normalize(NormalizationForm.FormC)
                    .Contains(searchString.ToLower().Normalize(NormalizationForm.FormC)) 
                    || 
                    p.Details.ToLower().Normalize(NormalizationForm.FormC)
                    .Contains(searchString.ToLower().Normalize(NormalizationForm.FormC))
                    ||
                    p.Brand.Name.ToLower().Normalize(NormalizationForm.FormC)
                    .Contains(searchString.ToLower().Normalize(NormalizationForm.FormC))
                    ||
                    p.Shop.Name.ToLower().Normalize(NormalizationForm.FormC)
                    .Contains(searchString.ToLower().Normalize(NormalizationForm.FormC))
                    ).ToList();
                return View("Index",filteredResult);
            }
            return View("Index", allProducts);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var productDetails = await _service.GetByIdAsync(id); // var mı/yok mu

            if (productDetails == null) return View("NotFound");

            return View(productDetails);
        }

        // Post
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productDetails = await _service.GetByIdAsync(id);

            if (productDetails == null) return View("NotFound");

            var shopId = productDetails.ShopId;
            await _service.DeleteAsync(id);

            return RedirectToAction("Details","Shops", new {Id=shopId});

        }
    }
}
