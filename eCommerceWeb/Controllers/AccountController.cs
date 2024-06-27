using eCommerceWeb.Data;
using eCommerceWeb.Data.Interfaces;
using eCommerceWeb.Data.Static;
using eCommerceWeb.Models;
using eCommerceWeb.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace eCommerceWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IShopService _shopService;
        private readonly AppDbContext _context;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IShopService shopService, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _shopService = shopService;
            _context = context;
        }

        public async Task<IActionResult> Login()
        {
            var response = new LoginVM();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }

            var user = await _userManager.FindByEmailAsync(loginVM.Email);

            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);

                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }

                TempData["Error"] = "Yanlış kullanıcı bilgileri...Lütfen kontrol ediniz...";

                return View(loginVM);
            }


            TempData["Error"] = "Yanlış kullanıcı bilgileri...Lütfen kontrol ediniz...";

            return View(loginVM);

        }

        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVM);
            }

            var user = await _userManager.FindByEmailAsync(registerVM.Email);
            if (user != null)
            {
                TempData["Error"] = "Bu e-posta adresi başka biri tarafında kullanılmakta";
                return View(registerVM);
            }

            var newUser = new ApplicationUser()
            {
                FullName = registerVM.FullName,
                Email = registerVM.Email,
                UserName = registerVM.Email,
                EmailConfirmed = true
            };

            var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);

            if (newUserResponse.Succeeded)
            {
                if (registerVM.IsSeller)
                {
                    await _userManager.AddToRoleAsync(newUser, UserRoles.Seller);

                    var newShop = new Shop()
                    {
                        Name = registerVM.ShopName,
                        About = registerVM.ShopAbout,
                        PictureUrl = registerVM.ShopPicture,
                        ApplicationUserId = newUser.Id
                    };
                    await _shopService.AddAsync(newShop);
                }
                else
                {
                    await _userManager.AddToRoleAsync(newUser, UserRoles.User);
                }
                await _signInManager.SignInAsync(newUser, isPersistent: false);
            }

            return View("RegisterCompleted");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
        public IActionResult AccessDenied(string returnURL)
        {
            return View();
        }

        [HttpGet]
        [Route("Account/Delete/{id:length(36)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpGet]
        [Route("Account/Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var shop = await _shopService.GetByIdAsync(id);
            var user = await _userManager.FindByIdAsync(shop.ApplicationUserId);
            if (user == null)
            {
                return NotFound();
            }

            ViewBag.Shop = shop;
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string userId, string confirmationWord)
        {
            

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return View("NotFound");
            }

            if (confirmationWord != user.Id) return View(user);

            if (await _userManager.IsInRoleAsync(user, UserRoles.Seller))
            {
                var shop = await _context.Shops.FirstOrDefaultAsync(s => s.ApplicationUserId == user.Id);
                if (shop != null) { await _shopService.DeleteAsync(shop.Id); }
            }

            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                //return await Logout();
                await _signInManager.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }
            else return View(user);
        }
    }
}
