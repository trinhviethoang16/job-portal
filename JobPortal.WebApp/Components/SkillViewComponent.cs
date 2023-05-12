using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobPortal.Data.DataContext;
using JobPortal.Data.Entities;
using System;

namespace JobPortal.WebApp.Components
{
    public class SkillViewComponent : ViewComponent
    {
        private readonly DataDbContext _context;

        public SkillViewComponent(DataDbContext context)
        {
            this._context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Skill> skillList = await _context.Skills.ToListAsync();
            return View(skillList);
        }
    }
}
