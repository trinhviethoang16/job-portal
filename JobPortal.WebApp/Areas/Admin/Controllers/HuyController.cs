using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using JobPortal.Data.DataContext;
using JobPortal.Data.Entities;
using JobPortal.Data.ViewModel;

namespace JobPortal.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/auth")]
    [Route("admin")]
    [Route("Account")]
    public class AccountController : Controller
    {
        //private readonly DataDbContext _context;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<AppUser> _logger;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ILogger<AppUser> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }
        

        [HttpGet]
        [Route("login")]
        //[Route("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        //[Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel userModel)
        {
            string returnUrl = Url.Content("~/admin/index");
            //ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                
                var result = await _signInManager.PasswordSignInAsync(userModel.Email, userModel.Password, false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return LocalRedirect(returnUrl);
                }
                //if (result.RequiresTwoFactor)
                //{
                //    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl });
                //}
                //if (result.IsLockedOut)
                //{
                //    _logger.LogWarning("User account locked out.");
                //    return RedirectToPage("./Lockout");
                //}
                //else
                //{
                //    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                //    return View();
                //}
            }
            // If we got this far, something failed, redisplay form
            return View();
        }

    }
}
