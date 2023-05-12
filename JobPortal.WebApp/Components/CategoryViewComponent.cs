using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobPortal.Data.DataContext;
using JobPortal.Data.Entities;
using System;

namespace JobPortal.WebApp.Components
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly DataDbContext _context;

        public CategoryViewComponent(DataDbContext context)
        {
            this._context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Category> cateList = await _context.Categories.ToListAsync();
            return View(cateList);
        }
    }
}
