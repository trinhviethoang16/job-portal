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
        private readonly DataDbContext _context;

        public EmployerController(DataDbContext context)
        {
            this._context = context;
        }

        [Route("register/{id}")]
        public IActionResult Register()
        {
            ViewData["ProvinceId"] = new SelectList(_context.Provinces.OrderBy(p => p.Id), "Id", "Name");
            ViewData["CountryId"] = new SelectList(_context.Countries.OrderBy(p => p.Name), "Id", "Name");
            return View();
        }

        [Route("register/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Guid id, UpdateEmployerViewModel model)
        {
            string POST_IMAGE_PATH = "images/employers/";

            AppUser employer = _context.AppUsers.Where(u => u.Id == id).First();
            employer.FullName = model.FullName;
            employer.Slug = TextHelper.ToUnsignString(model.FullName ?? employer.FullName).ToLower();
            var image = UploadImage.UploadImageFile(model.UrlAvatar, POST_IMAGE_PATH);
            employer.UrlAvatar = image;
            employer.Email = employer.UserName = model.Email;
            employer.NormalizedEmail = employer.NormalizedUserName = (employer.Email ?? model.Email).ToUpper();
            employer.CreateDate = DateTime.Now;
            employer.ProvinceId = model.ProvinceId;
            employer.Description = model.Description;
            employer.Contact = model.Contact;
            employer.Content = model.Content;
            employer.WorkingDays = model.WorkingDays;
            employer.CompanySize = model.CompanySize;
            employer.Location = model.Location;
            employer.WebsiteURL = model.WebsiteURL;
            employer.ProvinceId = model.ProvinceId;
            employer.CountryId = model.CountryId;
            employer.Phone = model.Phone;
            employer.Status = 1; // waiting to confirm
            _context.Update(employer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        [Route("update/{id}")]
        public async Task<IActionResult> Update(Guid id)
        {
            ViewData["ProvinceId"] = new SelectList(_context.Provinces.OrderBy(p => p.Id), "Id", "Name");
            ViewData["CountryId"] = new SelectList(_context.Countries.OrderBy(p => p.Name), "Id", "Name");
            var employer = await _context.AppUsers.Where(e => e.Id == id).FirstAsync();
            return View(employer);
        }

        [Route("update/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Guid id, UpdateEmployerViewModel model)
        {
            string POST_IMAGE_PATH = "images/employers/";

            AppUser employer = _context.AppUsers.Where(u => u.Id == id).First();

            //fix bug for null value
            if (model.FullName != null)
            {
                employer.FullName = model.FullName;
                employer.Slug = TextHelper.ToUnsignString(model.FullName ?? employer.FullName).ToLower();
            }

            //fix bug for null value
            if (model.UrlAvatar != null)
            {
                string oldLogoImage = employer.UrlAvatar;
                var newLogoImage = UploadImage.UploadImageFile(model.UrlAvatar, POST_IMAGE_PATH);
                employer.UrlAvatar = newLogoImage;
                if (!string.IsNullOrEmpty(oldLogoImage))
                {
                    string oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "employers", oldLogoImage);
                    DeleteImage.DeleteImageFile(oldImagePath);
                }
            }
            employer.Email = employer.UserName = model.Email;
            employer.NormalizedEmail = employer.NormalizedUserName = (employer.Email ?? model.Email).ToUpper();
            employer.ProvinceId = model.ProvinceId;
            employer.Description = model.Description;
            employer.Contact = model.Contact;
            employer.Content = model.Content;
            employer.WorkingDays = model.WorkingDays;
            employer.CompanySize = model.CompanySize;
            employer.Location = model.Location;
            employer.WebsiteURL = model.WebsiteURL;
            employer.ProvinceId = model.ProvinceId;
            employer.CountryId = model.CountryId;
            employer.Phone = model.Phone;
            _context.Update(employer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}