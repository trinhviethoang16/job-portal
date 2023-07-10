using System.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobPortal.Data.DataContext;
using JobPortal.Data.Entities;
using JobPortal.Data.ViewModel;
using JobPortal.Common;
using X.PagedList;

namespace JobPortal.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/category")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly DataDbContext _context;

        public CategoryController(DataDbContext context)
        {
            _context = context;
        }

        [Route("index")]
        [Route("")]
        public async Task<IActionResult> Index(int? page)
        {
            int pageSize = 5; //number of categories per page

            var categoríes = await _context.Categories.OrderByDescending(i => i.Id).ToListAsync();
            return View(categoríes.ToPagedList(page ?? 1, pageSize));
        }

        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Slug = TextHelper.ToUnsignString(model.Name).ToLower()
                };
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [Route("update/{id}")]
        public IActionResult Update(int id)
        {
            var category = _context.Categories.Where(u => u.Id == id).First();
            return View(category);
        }

        [Route("update/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, UpdateCategoryViewModel model)
        {
            Category category = _context.Categories.Where(u => u.Id == id).First();
            category.Name = model.Name;
            category.Description = model.Description;
            category.Slug = TextHelper.ToUnsignString(category.Name).ToLower();
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return Redirect("/admin/category");
        }

        [HttpGet("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Category category = _context.Categories.Where(d => d.Id == id).First();
                _context.Categories.Remove(category);
                _context.SaveChanges();
                return Redirect("/admin/category");
            }
            catch (System.Exception)
            {
                return Redirect("/admin/category");
            }
        }

        [HttpPost("delete-selected")]
        public async Task<IActionResult> DeleteSelected(int[] listDelete)
        {
            foreach (int id in listDelete)
            {
                var category = await _context.Categories.FindAsync(id);
                _context.Categories.Remove(category);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
