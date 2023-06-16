using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobPortal.Data.DataContext;
using JobPortal.Data.Entities;
using JobPortal.Data.ViewModel;
using Microsoft.AspNetCore.Authorization;
using JobPortal.Common;

namespace JobPortal.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/skill")]
    [Authorize(Roles = "Admin")]
    public class SkillController : Controller
    {
        private readonly DataDbContext _context;

        public SkillController(DataDbContext context)
        {
            _context = context;
        }

        [Route("index")]
        [Route("")]
        public async Task<IActionResult> Index()
        {
            var skill = await _context.Skills.OrderByDescending(i => i.Id).ToListAsync();
            return View(skill);
        }

        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateSkillViewModel model)
        {
            if (ModelState.IsValid)
            {
                Skill skill = new Skill()
                {
                    Name = model.Name,
                    Slug = TextHelper.ToUnsignString(model.Name).ToLower()
                };
                _context.Skills.Add(skill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [Route("update/{id}")]
        public IActionResult Update(int id)
        {
            var skill = _context.Skills.Where(u => u.Id == id).First();
            return View(skill);
        }

        [Route("update/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, UpdateSkillViewModel model)
        {
            Skill skill = _context.Skills.Where(u => u.Id == id).First();
            skill.Name = model.Name;
            skill.Slug = TextHelper.ToUnsignString(model.Name).ToLower();
            _context.Skills.Update(skill);
            await _context.SaveChangesAsync();
            return Redirect("/admin/skill");
        }

        [HttpGet("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Skill skill = _context.Skills.Where(p => p.Id == id).First();
                _context.Skills.Remove(skill);
                _context.SaveChanges();
                return Redirect("/admin/skill");
            }
            catch (System.Exception)
            {
                return Redirect("/admin/skill");
            }
        }

        [HttpPost("delete-selected")]
        public async Task<IActionResult> DeleteSelected(int[] listDelete)
        {
            foreach (int id in listDelete)
            {
                var skill = await _context.Skills.FindAsync(id);
                _context.Skills.Remove(skill);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
