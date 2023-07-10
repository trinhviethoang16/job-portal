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
    [Route("admin/province")]
    [Authorize(Roles = "Admin")]
    public class ProvinceController : Controller
    {
        private readonly DataDbContext _context;

        public ProvinceController(DataDbContext context)
        {
            _context = context;
        }

        [Route("index")]
        [Route("")]
        public async Task<IActionResult> Index(int? page)
        {
            int pageSize = 5; //number of provinces per page

            var province = await _context.Provinces.OrderBy(i => i.Id).ToListAsync();
            return View(province.ToPagedList(page ?? 1, pageSize));
        }

        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProvinceViewModel model)
        {
            if (ModelState.IsValid)
            {
                Province province = new Province()
                {
                    Name = model.Name,
                    Slug = TextHelper.ToUnsignString(model.Name).ToLower()
                };
                _context.Provinces.Add(province);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [Route("update/{id}")]
        public IActionResult Update(int id)
        {
            var province = _context.Provinces.Where(u => u.Id == id).First();
            return View(province);
        }

        [Route("update/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, UpdateProvinceViewModel model)
        {
            Province province = _context.Provinces.Where(u => u.Id == id).First();
            province.Name = model.Name;
            province.Slug = TextHelper.ToUnsignString(province.Name).ToLower();
            _context.Provinces.Update(province);
            await _context.SaveChangesAsync();
            return Redirect("/admin/province");
        }

        [HttpGet("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Province province = _context.Provinces.Where(d => d.Id == id).First();
                _context.Provinces.Remove(province);
                _context.SaveChanges();
                return Redirect("/admin/province");
            }
            catch (System.Exception)
            {
                return Redirect("/admin/province");
            }
        }

        [HttpPost("delete-selected")]
        public async Task<IActionResult> DeleteSelected(int[] listDelete)
        {
            foreach (int id in listDelete)
            {
                var province = await _context.Provinces.FindAsync(id);
                _context.Provinces.Remove(province);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
