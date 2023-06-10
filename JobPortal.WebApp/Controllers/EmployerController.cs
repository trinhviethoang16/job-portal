using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobPortal.Data.DataContext;
using JobPortal.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using JobPortal.Data.ViewModel;
using JobPortal.Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Principal;

namespace JobPortal.WebApp.Controllers
{
    [Route("register-employer")]
    public class EmployerController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly DataDbContext _context;

        public EmployerController(UserManager<AppUser> userManager, DataDbContext context)
        {
            this.userManager = userManager;
            this._context = context;
        }

        [Route("{id}")]
        public async Task<IActionResult> Register(Guid id)
        {
            var user = await _context.AppUsers.Where(u => u.Id == id).FirstAsync();
            // check role
            if (!User.IsInRole("User"))
            {
                return RedirectToAction(nameof(AccessDenied));
            }
            else
            {
                return View(user);
            }
        }

        [Route("{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Guid id, UpdateEmployerViewModel model, string returnUrl)
        {
            string POST_IMAGE_PATH = "images/employers/";

            if (model.UrlAvatar != null)
            {
                AppUser user = _context.AppUsers.Where(u => u.Id == id).First();
                user.FullName = model.FullName;
                var image = UploadImage.UploadImageFile(model.UrlAvatar, POST_IMAGE_PATH);
                user.UrlAvatar = image;
                user.Description = model.Description;
                user.Contact = model.Contact;
                user.Location = model.Location;
                user.WebsiteURL = model.WebsiteURL;
                user.Status = model.Status = 1; //for pending
                _context.Update(user);
                await _context.SaveChangesAsync();
            }
            else
            {
                return RedirectToAction(nameof(Fail));
            }
            return RedirectToAction(nameof(Success));
        }

        [Route("access-denied")]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [Route("success")]
        public IActionResult Success()
        {
            return View();
        }

        [Route("fail")]
        public IActionResult Fail()
        {
            return View();
        }
    }
}