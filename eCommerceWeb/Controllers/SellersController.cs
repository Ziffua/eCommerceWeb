using eCommerceWeb.Data;
using eCommerceWeb.Data.Interfaces;
using eCommerceWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerceWeb.Controllers
{
    public class SellersController : Controller
    {
        //Service for the CRUD operation methods of the model
        private readonly ISellerService _service;
        public SellersController(ISellerService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var sellerData = await _service.GetAllAsync(); //Retrieve all data in the Sellers table from db
            return View(sellerData);
        }

        [HttpGet]
        //Since that page doesn't require anything to get done asynchronously, it is not a Task
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        //The method that will be run when the Create form posts a model with its data
        public async Task<IActionResult> Create([Bind("Name","About","PictureUrl")]Seller seller) 
        {
            if (!ModelState.IsValid)
            {
                return View(seller);
            }
            await _service.AddAsync(seller);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        //Details has only HttpGet action and no HttpPost
        public async Task<IActionResult> Details(int id)
        {
            //Get the model to fill the related fields on the view page
            var sellerData = await _service.GetByIdAsync(id); 
            if(sellerData == null) return View("NotFound");
            return View(sellerData);
        }

        [HttpGet]
        //id comes from the selected model item
        public async Task<IActionResult> Edit(int id)
        {
            //Edit page requires the selected model to display its current data
            var sellerData = await _service.GetByIdAsync(id);
            if (sellerData == null) return View("NotFound"); //Check if the item exists
            return View(sellerData);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id", "Name", "About", "PictureUrl")] Seller editedSeller)
        {
            if(!ModelState.IsValid) return View(editedSeller); //If the model data doesn't meet the requirements, return back to the same page with the previously filled data remaining
            await _service.UpdateAsync(editedSeller);
            //return RedirectToAction(nameof(Details), editedSeller.Id);
            return RedirectToAction(nameof(Index));            
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id) 
        {
            var sellerData = await _service.GetByIdAsync(id);
            if (sellerData == null) return View("NotFound");//Check if the item exists
            return View(sellerData);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id, string confirmationWord)
        {
            var seller = await _service.GetByIdAsync(id);
            if (confirmationWord != seller.Name) return View(seller);//If the seller name is not confirmed, don't delete
            if (seller == null) return View("NotFound");//Check if the item exists
            await _service.DeleteAsync(id);//If so, not anymore... 
            return RedirectToAction(nameof(Index));
        }

    }
}
