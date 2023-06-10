using JobPortal.Data.DataContext;
using JobPortal.Data.Entities;
using JobPortal.Data.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.WebApp.Controllers
{
    [Route("")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly DataDbContext _context;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, DataDbContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this._context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = model.Email,
                    FullName = model.FullName,
                    Age = model.Age,
                    Address = model.Address,
                    Email = model.Email
                };
                var result = await userManager.CreateAsync(user, model.Password);
                //đăng ký thành công thì chuyển trang đăng nhập
                if (result.Succeeded)
                {
                    // Add role "user" cho User mới tạo
                    await userManager.AddToRoleAsync(user, "User");
                    return RedirectToAction(nameof(Login));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("login")]
        public IActionResult Login()
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
                    return RedirectToAction("index", "home");
                }
            }
            return View(model);
        }

        [Route("logout")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }
    }
}
