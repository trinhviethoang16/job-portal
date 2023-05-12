//using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Encodings.Web;
using System.Text;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Globalization;
using JobPortal.Data.DataContext;
using JobPortal.Data.Entities;
using JobPortal.Data.ViewModel;

namespace ProjectJobPortal.Controllers
{
    public class UserController : Controller
    {
        private readonly DataDbContext _context;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserStore<AppUser> _userStore;
        private readonly ILogger<AppUser> _logger;
        //private readonly IEmailSender _sender;
        //IEmailSender sender
        public UserController( ILogger<AppUser> logger, IUserStore<AppUser> userStore, UserManager<AppUser> userManager, DataDbContext context, SignInManager<AppUser> signInManager)
        {
            //_sender = sender;
            _logger = logger;
            _signInManager = signInManager;
            _context = context;
            _userManager = userManager;
            _userStore = userStore;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel userModel)
        {
            //string returnUrl = Url.Content("~/Identity/Account/RegisterConfirmation");
            //ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = CreateUser();
                user.Email = userModel.Email;
                user.Phone = userModel.Phone;
                user.Address = userModel.Address;
                user.Age = userModel.Age;
                user.FullName = userModel.FullName;
                //user.Image = userModel.Image;
                //user.Introduce = userModel.Introduce;
                //user.Description = userModel.Description;
                //user.ShortDescription = userModel.ShortDescription;
                //user.Logo = userModel.Logo;
                //user.City = userModel.City;
                //user.Contact = userModel.Contact;
                //user.WebsiteURL = userModel.WebsiteURL;
                //user.Location = userModel.Location;
                //user.SetRole = userModel.SetRole;
                //user.IsAdmin = userModel.IsAdmin;

                await _userStore.SetUserNameAsync(user, userModel.Email, CancellationToken.None);
                //await _emailStore.SetEmailAsync(user, userModel.Email, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, userModel.Password);

                if (result.Succeeded)
                {
                    //_logger.LogInformation("User created a new account with password.");

                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = "" },
                        protocol: Request.Scheme);

                    //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    //@ViewBag.EmailConfirmationUrl
                    ViewBag.EmailConfirmationUrl = callbackUrl;

                    //@ViewBag.DisplayConfirmAccountLink
                    ViewBag.DisplayConfirmAccountLink = true;

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return View("RegisterConfirmation", new { email = userModel.Email, returnUrl = "" });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect("Home/Index");
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View();
        }

        private AppUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<AppUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(AppUser)}'. " +
                    $"Ensure that '{nameof(AppUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel userModel)
        {
            string returnUrl = Url.Content("~/Home/Index");
            //ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
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

        public async Task<IActionResult> Logout(string returnUrl)
        {
            await _signInManager.SignOutAsync();
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            return LocalRedirect("Home/Index");
        }
    }
}
