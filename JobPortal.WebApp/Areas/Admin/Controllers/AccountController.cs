using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using JobPortal.Data.Entities;
using JobPortal.Data.ViewModel;
using JobPortal.Data.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNet.Identity;

namespace JobPortal.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/auth")]
    [Route("admin")]
    [Route("Account")]
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly UserManager<AppUser> userManager;
        private readonly DataDbContext dataDbContext;

        public AccountController(SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, UserManager<AppUser> userManager, DataDbContext dataDbContext)
        {
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.dataDbContext = dataDbContext;
        }

        //public async Task<bool> IsUserAdmin(string userId)
        //{
        //    var user = await userManager.FindByIdAsync(userId);
        //    return await userManager.IsInRoleAsync(user, "Admin");
        //}

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
                        return RedirectToAction("accessdenied", "account");
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


        [HttpGet]
        [Route("access-denied")]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}


//[HttpPost]
//[AllowAnonymous]
//[Route("login")]
//public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
//{
//    if (!ModelState.IsValid)
//    {
//        var result = await signInManager.PasswordSignInAsync(
//            model.Email,
//            model.Password,
//            model.RememberMe,
//            false);
//        if (result.Succeeded)
//        {
//            string? roleName = dataDbContext.Users.FirstOrDefault(x => model.Email == x.Email).RoleName;
//            if (!string.IsNullOrEmpty(returnUrl))
//            {
//                return Redirect(returnUrl);
//            }
//            //else if (!model.Email.Equals("admin@gmail.com"))
//            //{
//            //    await signInManager.SignOutAsync();
//            //    return RedirectToAction("accessdenied", "account");
//            //}
//            else if (!roleName.Equals("Admin"))
//            {
//                await signInManager.SignOutAsync();
//                return RedirectToAction("accessdenied", "account");
//            }
//            else
//            {
//                return RedirectToAction("index", "home");
//            }
//        }
//    }
//    return View(model);
//}