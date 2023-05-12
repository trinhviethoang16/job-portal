using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobPortal.Data.DataContext;
using JobPortal.Data.Entities;
using System;

namespace JobPortal.WebApp.Components
{
    public class ProvinceViewComponent : ViewComponent
    {
        private readonly DataDbContext _context;

        public ProvinceViewComponent(DataDbContext context)
        {
            this._context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Province> proList = await _context.Provinces.ToListAsync();
            return View(proList);
        }
    }
}
