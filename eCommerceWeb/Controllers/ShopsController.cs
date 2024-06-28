using eCommerceWeb.Data;
using eCommerceWeb.Data.Interfaces;
using eCommerceWeb.Data.Static;
using eCommerceWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerceWeb.Controllers
{
    public class ShopsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        //Service for the CRUD operation methods of the model
        private readonly IShopService _service;
        private readonly AppDbContext _context;
        public ShopsController(UserManager<ApplicationUser> userManager, IShopService service, AppDbContext context)
        {
            _userManager = userManager;
            _service = service;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var shopData = await _service.GetAllAsync(); //Retrieve all data in the shops table from db
            return View(shopData);
        }

        [HttpGet]
        //Details has only HttpGet action and no HttpPost
        public async Task<IActionResult> Details(int id)
        {
            //Get the model to fill the related fields on the view page
            var shopData = await _service.GetByIdAsync(id, s => s.Products); 
            if(shopData == null) return View("NotFound");
            return View(shopData);
        }

        [Authorize(Roles = $"{UserRoles.Admin},{UserRoles.Seller}")]
        [HttpGet]
        //id comes from the selected model item
        public async Task<IActionResult> Edit(int id)
        {
            //Edit page requires the selected model to display its current data
            var shopData = await _service.GetByIdAsync(id, s=>s.Products);           
            if (shopData == null) return View("NotFound"); //Check if the item exists
            return View(shopData);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id", "Name", "About", "PictureUrl", "ApplicationUserId")] Shop editedShop)
        {
            if(!ModelState.IsValid) return View(editedShop); //If the model data doesn't meet the requirements, return back to the same page with the previously filled data remaining
            await _service.UpdateAsync(editedShop);
            return RedirectToAction(nameof(Details), new {id=editedShop.Id});
          
        }

        [Authorize(Roles = $"{UserRoles.Admin},{UserRoles.Seller}")]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var shopData = await _service.GetByIdAsync(id);
            if (shopData == null) return View("NotFound");//Check if the item exists
            return View(shopData);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id, string confirmationWord)
        {
            var shop = await _service.GetByIdAsync(id);
            if (confirmationWord != shop.Name) return View(shop);//If the shop name is not confirmed, don't delete
            if (shop == null) return View("NotFound");//Check if the item exists
            await _service.DeleteAsync(id);//If so, not anymore... 
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = UserRoles.Seller)]
        public async Task<IActionResult> MyShop()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var shop = await _context.Shops.FirstOrDefaultAsync(s => s.ApplicationUserId == user.Id);
            return RedirectToAction("Edit", "Shops", new { id = shop.Id});
        }

    }
}
