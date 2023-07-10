using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobPortal.Data.DataContext;
using JobPortal.Data.Entities;
using JobPortal.Data.ViewModel;
using Microsoft.AspNetCore.Authorization;
using JobPortal.Common;
using X.PagedList;

namespace JobPortal.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/title")]
    [Authorize(Roles = "Admin")]
    public class TitleController : Controller
    {
        private readonly DataDbContext _context;

        public TitleController(DataDbContext context)
        {
            _context = context;
        }

        [Route("")]
        [Route("index")]
        public async Task<IActionResult> Index(int? page)
        {
            int pageSize = 10; //number of titles per page

            var title = await _context.Titles.OrderBy(t => t.Name).ToListAsync();
            return View(title.ToPagedList(page ?? 1, pageSize));
        }

        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTitleViewModel model)
        {
            if (ModelState.IsValid)
            {
                Title title = new Title()
                {
                    Name = model.Name,
                    Slug = TextHelper.ToUnsignString(model.Name).ToLower(),
                };
                _context.Titles.Add(title);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [Route("update/{id}")]
        public IActionResult Update(int id)
        {
            var title = _context.Titles.Where(t => t.Id == id).First();
            return View(title);
        }

        [Route("update/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, UpdateTitleViewModel model)
        {
            Title title = _context.Titles.Where(t => t.Id == id).First();
            title.Name = model.Name;
            title.Slug = TextHelper.ToUnsignString(title.Name).ToLower();
            _context.Titles.Update(title);
            await _context.SaveChangesAsync();
            return Redirect("/admin/title");
        }

        [HttpGet("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Title title = _context.Titles.Where(t => t.Id == id).First();
                _context.Titles.Remove(title);
                _context.SaveChanges();
                return Redirect("/admin/title");
            }
            catch (System.Exception)
            {
                return Redirect("/admin/title");
            }
        }

        [HttpPost("delete-selected")]
        public async Task<IActionResult> DeleteSelected(int[] listDelete)
        {
            foreach (int id in listDelete)
            {
                var title = await _context.Titles.FindAsync(id);
                _context.Titles.Remove(title);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}