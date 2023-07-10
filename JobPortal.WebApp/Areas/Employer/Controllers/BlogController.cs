using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobPortal.Data.DataContext;
using JobPortal.Data.Entities;
using JobPortal.Data.ViewModel;
using Microsoft.AspNetCore.Authorization;
using JobPortal.Common;
using X.PagedList;

namespace JobPortal.WebApp.Areas.Employer.Controllers
{
    [Area("Employer")]
    [Route("employer/blog")]
    [Authorize(Roles = "Employer")]
    public class BlogController : Controller
    {
        private readonly DataDbContext _context;

        public BlogController(DataDbContext context)
        {
            _context = context;
        }

        [Route("{id}")]
        [Route("")]
        public async Task<IActionResult> Index(Guid id, int? page)
        {
            int pageSize = 5; //number of blogs per page

            var blogs = await _context.Blogs
                .Where(b => b.AppUserId == id)
                .Include(b => b.AppUser)
                .OrderByDescending(b => b.CreateDate)
                .ToListAsync();
            return View(blogs.ToPagedList(page ?? 1, pageSize));
        }

        [Route("create/{id}")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Guid id, CreateBlogViewModel model)
        {
            if (ModelState.IsValid)
            {
                string POST_IMAGE_PATH = "images/blogs/";

                if (model.Image != null)
                {
                    var image = UploadImage.UploadImageFile(model.Image, POST_IMAGE_PATH);

                    Blog blog = new Blog()
                    {
                        Author = model.Author,
                        Title = model.Title,
                        Slug = TextHelper.ToUnsignString(model.Title).ToLower(),
                        CreateDate = DateTime.Now,
                        Content = model.Content,
                        Image = image,
                        Description = model.Description,
                        AppUserId = id
                    };
                    _context.Blogs.Add(blog);
                    await _context.SaveChangesAsync();
                    return Redirect("/employer/blog/" + id);
                }
            }
            return View(model);
        }

        [Route("update/{id}")]
        public IActionResult Update(int id)
        {
            var blog = _context.Blogs.Where(u => u.Id == id).First();
            return View(blog);
        }

        [Route("update/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, UpdateBlogViewModel model)
        {
            Blog blog = _context.Blogs.Where(b => b.Id == id).First();
            blog.Author = model.Author;
            blog.Title = model.Title;
            blog.Slug = TextHelper.ToUnsignString(model.Title).ToLower();
            blog.Content = model.Content;
            blog.Description = model.Description;
            _context.Blogs.Update(blog);
            await _context.SaveChangesAsync();
            return Redirect("/employer/blog/" + blog.AppUserId);
        }

        [Route("update-image/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateImage(int id, IFormFile Image)
        {
            string POST_IMAGE_PATH = "images/blogs/";

            if (Image != null)
            {
                Blog blog = _context.Blogs.Where(b => b.Id == id).First();
                string oldImage = blog.Image;
                var newImage = UploadImage.UploadImageFile(Image, POST_IMAGE_PATH);
                blog.Image = newImage;
                _context.Update(blog);
                await _context.SaveChangesAsync();

                if (!string.IsNullOrEmpty(oldImage))
                {
                    string oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "blogs", oldImage);
                    DeleteImage.DeleteImageFile(oldImagePath);
                }

                return Redirect("/employer/blog/update/" + id);
            }
            return Redirect("/employer/blog/update/" + id);
        }

        [HttpGet("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Blog blog = _context.Blogs.Where(b => b.Id == id).First();
                if (blog != null)
                {
                    string image = blog.Image;
                    _context.Blogs.Remove(blog);
                    _context.SaveChanges();
                    if (!string.IsNullOrEmpty(image))
                    {
                        string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "blogs", image);
                        DeleteImage.DeleteImageFile(imagePath);
                    }
                }
                return Redirect("/employer/blog/" + blog.AppUserId);
            }
            catch (System.Exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost("delete-selected")]
        public async Task<IActionResult> DeleteSelected(int[] listDelete)
        {
            var blogs = await _context.Blogs
                .Where(j => listDelete.Contains(j.Id))
                .FirstOrDefaultAsync();

            foreach (int id in listDelete)
            {
                var blog = await _context.Blogs.FindAsync(id);
                _context.Blogs.Remove(blog);

                if (blog != null)
                {
                    string image = blog.Image;

                    _context.Blogs.Remove(blog);
                    _context.SaveChanges();

                    if (!string.IsNullOrEmpty(image))
                    {
                        string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "blogs", image);
                        DeleteImage.DeleteImageFile(imagePath);
                    }
                }
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { id = blogs.Id });
        }
    }
}