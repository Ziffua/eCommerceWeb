using eCommerceWeb.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eCommerceWeb.Data.Interfaces;
using eCommerceWeb.Models;
using eCommerceWeb.Data.Static;
using Microsoft.AspNetCore.Authorization;

namespace eCommerceWeb.Controllers
{
    
    public class BrandsController : Controller
    {
        private readonly IBrandService _service;
        public BrandsController(IBrandService service)
        {
            _service = service;
        }

        [Authorize(Roles = UserRoles.Admin)]
        // GET: BrandController
        public async Task<IActionResult> Index()
        {
            var brandData = await _service.GetAllAsync(); //Retrieve all data in the Shops table from db
            return View(brandData);
        }

        //Get
        [Authorize(Roles = $"{UserRoles.Admin},{UserRoles.Seller}")]
        [HttpGet]
        //Since that page doesn't require anything to get done asynchronously, it is not a Task
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //The method that will be run when the Create form posts a model with its data
        public async Task<IActionResult> Create([Bind("Name", "Description", "LogoUrl")] Brand brand, string? isSeller)
        {
            if (!ModelState.IsValid)
            {
                return View(brand);
            }
            
            await _service.AddAsync(brand);

            if(isSeller=="1") return RedirectToAction("Create", "Products");
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        //Details has only HttpGet action and no HttpPost
        public async Task<IActionResult> Details(int id)
        {
            //Get the model to fill the related fields on the view page
            var brandData = await _service.GetByIdAsync(id, b=>b.Products);
            if (brandData == null) return View("NotFound");
            return View(brandData);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet]
        //id comes from the selected model item
        public async Task<IActionResult> Edit(int id)
        {
            //Edit page requires the selected model to display its current data
            var brandData = await _service.GetByIdAsync(id, b => b.Products);
            if (brandData == null) return View("NotFound"); //Check if the item exists
            return View(brandData);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id", "Name", "Description", "LogoUrl")] Brand editedBrand)
        {
            if (!ModelState.IsValid) return View(editedBrand); //If the model data doesn't meet the requirements, return back to the same page with the previously filled data remaining
            await _service.UpdateAsync(editedBrand);
            return RedirectToAction(nameof(Details), new {id=editedBrand.Id});
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var brandData = await _service.GetByIdAsync(id);
            if (brandData == null) return View("NotFound");//Check if the item exists
            return View(brandData);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var brand = await _service.GetByIdAsync(id);
            if (brand == null) return View("NotFound");//Check if the item exists
            await _service.DeleteAsync(id);//If it does, not anymore... 
            return RedirectToAction(nameof(Index));
        }
    }
}
