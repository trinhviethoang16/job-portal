using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using JobPortal.Data.Entities;
using JobPortal.Data.ViewModel;
using JobPortal.Data.DataContext;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/auth")]
    [Route("admin")]
    [Route("Account")]
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpGet]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                            model.Email,
                            model.Password,
                            model.RememberMe,
                            false);
                if (result.Succeeded)
                {
                    //get email from login site and check 
                    var user = await userManager.FindByEmailAsync(model.Email);
                    //get role by user
                    var roles = await userManager.GetRolesAsync(user);
                    if (user == null || !await userManager.CheckPasswordAsync(user, model.Password))
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        return View(model);
                    }
                    // check role
                    else if (!roles.Contains("Admin"))
                    {
                        await signInManager.SignOutAsync();
                        ModelState.AddModelError(string.Empty, "This page is only for admin account.");
                    }
                    else if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("index", "home");
                    }
                }
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }
    }
}