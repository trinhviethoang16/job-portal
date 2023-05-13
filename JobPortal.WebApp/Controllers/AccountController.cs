//using JobPortal.Data.DataContext;
//using JobPortal.Data.Entities;
//using JobPortal.Data.ViewModel;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;

//namespace Ecommerce.WebApp.Controllers
//{
//    [Route("")]
//    public class AccountController : Controller
//    {
//        private readonly UserManager<AppUser> userManager;
//        private readonly SignInManager<AppUser> signInManager;
//        private readonly DataDbContext _context;

//        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, DataDbContext context)
//        {
//            this.userManager = userManager;
//            this.signInManager = signInManager;
//            _context = context;
//        }

//        [HttpGet]
//        [AllowAnonymous]
//        [Route("dang-ky")]
//        public IActionResult Register()
//        {
//            return View();
//        }

//        [HttpPost]
//        [AllowAnonymous]
//        [Route("dang-ky")]
//        public async Task<IActionResult> Register(RegisterViewModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                var user = new AppUser
//                {
//                    UserName = model.Email,
//                    FirstName = model.FirstName,
//                    LastName = model.LastName,
//                    FullName = model.LastName + " " + model.FirstName,
//                    Email = model.Email
//                };
//                var result = await userManager.CreateAsync(user, model.Password);
//                if (result.Succeeded)
//                {
//                    await signInManager.SignInAsync(user, isPersistent: false);
//                    return RedirectToAction(nameof(Login));
//                }
//                foreach (var error in result.Errors)
//                {
//                    ModelState.AddModelError("", error.Description);
//                }
//            }
//            return View();
//        }

//        [HttpGet]
//        [AllowAnonymous]
//        [Route("dang-nhap")]
//        public async Task<IActionResult> Login()
//        {
//            return View();
//        }

//        [HttpPost]
//        [AllowAnonymous]
//        [Route("dang-nhap")]
//        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
//        {
//            if (!ModelState.IsValid)
//            {
//                var result = await signInManager.PasswordSignInAsync(
//                    model.Email,
//                    model.Password,
//                    model.RememberMe,
//                    false);
//                if (result.Succeeded)
//                {
//                    return RedirectToAction("index", "home");
//                }

//            }
//            return View(model);
//        }

//        [Route("dang-xuat")]
//        [AllowAnonymous]
//        [HttpGet]
//        public async Task<IActionResult> Logout()
//        {
//            await signInManager.SignOutAsync();
//            return RedirectToAction("index", "home");
//        }

//        // This method added for role tutorial
//        [HttpGet]
//        [AllowAnonymous]
//        [Route("opps")]
//        public IActionResult AccessDenied()
//        {
//            return View();
//        }
//    }
//}
