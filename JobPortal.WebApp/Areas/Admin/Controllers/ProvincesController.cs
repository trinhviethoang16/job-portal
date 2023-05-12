using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobPortal.Data.DataContext;
using JobPortal.Data.Entities;
using JobPortal.Data.ViewModel;

namespace JobPortal.WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("admin/province")]
    
    public class ProvincesController : Controller
    {
        private readonly DataDbContext _context;

        public ProvincesController(DataDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Provinces
        [Route("index")]
        [Route("")]
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Provinces.ToListAsync());
            return _context.Provinces != null ?
                        View(await _context.Provinces.ToListAsync()) :
                        Problem("Entity set 'ProjectJobPortalContext.Provinces'  is null.");
        }

        // GET: Admin/Provinces/Details/5
        //[HttpPost]
        [Route("detail")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Provinces == null)
            {
                return NotFound();
            }

            var province = await _context.Provinces
                .FirstOrDefaultAsync(m => m.Id == id);
            if (province == null)
            {
                return NotFound();
            }

            return View(province);
        }













        [Route("create")]
        public IActionResult Create()
        {
            ViewData["ProvinceID"] = new SelectList(_context.Provinces, "Id", "Name");
            return View();
        }

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Province province)
        {
            if (ModelState.IsValid)
            {
                _context.Add(province);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(province);
        }















        // GET: Admin/Provinces/Edit/5

        [Route("edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Provinces == null)
            {
                return NotFound();
            }

            var province = await _context.Provinces.FindAsync(id);
            if (province == null)
            {
                return NotFound();
            }
            return View(province);
        }

        // POST: Admin/Provinces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ParentID")] Province province)
        {
            if (id != province.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(province);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProvinceExists(province.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(province);
        }











        // GET: Admin/Provinces/Delete/5
//[HttpPost]
        [Route("delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Provinces == null)
            {
                return NotFound();
            }

            var province = await _context.Provinces
                .FirstOrDefaultAsync(m => m.Id == id);
            if (province == null)
            {
                return NotFound();
            }

            return View(province);
        }





        // POST: Admin/Provinces/Delete/5
        [Route("delete")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Provinces == null)
            {
                return Problem("Entity set 'ProjectJobPortalContext.Provinces'  is null.");
            }
            var province = await _context.Provinces.FindAsync(id);
            if (province != null)
            {
                _context.Provinces.Remove(province);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }





        private bool ProvinceExists(int id)
        {
            return _context.Provinces.Any(e => e.Id == id);
            //return (_context.Provinces?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
