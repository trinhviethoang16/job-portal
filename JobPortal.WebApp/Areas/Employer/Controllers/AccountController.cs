using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using JobPortal.Data.Entities;
using JobPortal.Data.ViewModel;
using System;
using JobPortal.Data.DataContext;

namespace JobPortal.WebApp.Areas.Employer.Controllers
{
    [Area("Employer")]
    [Route("employer/auth")]
    [Route("employer")]
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly DataDbContext dataDbContext;

        public AccountController(SignInManager<AppUser> signInManager, DataDbContext dataDbContext)
        {
            this.signInManager = signInManager;
            this.dataDbContext = dataDbContext;
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
                    string? roleName = dataDbContext.Users.FirstOrDefault(x => model.Email == x.Email).RoleName;
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else if (!roleName.Equals("Employer"))
                    {
                        await signInManager.SignOutAsync();
                        return RedirectToAction("accessdenied", "account");
                    }
                    else
                    {
                        return RedirectToAction("index", "home");
                    }
                }
            }
            return View(model);
        }

        [Route("logout")]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToRoute("index", "home");
        }

        [HttpGet]
        [Route("access-denied")]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}