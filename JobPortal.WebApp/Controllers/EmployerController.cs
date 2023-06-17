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
        public IActionResult Register()
        {
            ViewData["ProvinceId"] = new SelectList(_context.Provinces, "Id", "Name");
            return View();
        }

        [Route("{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Guid id, UpdateEmployerViewModel model, string returnUrl)
        {
            string POST_IMAGE_PATH = "images/employers/";

            AppUser user = _context.AppUsers.Where(u => u.Id == id).First();
            user.FullName = model.FullName;
            user.Slug = TextHelper.ToUnsignString(model.FullName ?? user.FullName).ToLower();
            var image = UploadImage.UploadImageFile(model.UrlAvatar, POST_IMAGE_PATH);
            user.CreateDate = DateTime.Now;
            user.ProvinceId = model.ProvinceId;
            user.UrlAvatar = image;
            user.Description = model.Description;
            user.Contact = model.Contact;
            user.Location = model.Location;
            user.WebsiteURL = model.WebsiteURL;
            user.ProvinceId = model.ProvinceId;
            user.Status = 1; // waiting
            _context.Update(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}