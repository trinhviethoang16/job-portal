using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobPortal.Data.DataContext;
using JobPortal.Data.Entities;
using System;

namespace JobPortal.WebApp.Components
{
    public class JobViewComponent : ViewComponent
    {
        private readonly DataDbContext _context;

        public JobViewComponent(DataDbContext context)
        {
            this._context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Job> jobList = await _context.Jobs.ToListAsync();
            return View(jobList);
        }
    }
}
