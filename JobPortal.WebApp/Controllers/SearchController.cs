using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobPortal.Data.DataContext;
using JobPortal.Data.Entities;

namespace JobPortal.WebApp.Controllers
{
    [Route("search")]
    public class SearchController : Controller
    {
        private readonly DataDbContext _context;

        public SearchController(DataDbContext context)
        {
            _context = context;
        }

        [Route("")]
        public async Task<IActionResult> Index(string q)
        {
            ViewBag.ListJobs = _context.Jobs.OrderBy(p => p.Id).Take(6).ToList();
            ViewBag.ListSkills = _context.Skills.OrderBy(s => s.Id).Take(10).ToList();
            ViewBag.ListProvinces = _context.Provinces.OrderBy(p => p.Id).ToList();
            ViewBag.ListTimes = _context.Times.OrderBy(t => t.Id).ToList();
            ViewBag.q = q;

            var jobs = await _context.Jobs.OrderByDescending(j => j.Id).ToListAsync();

            if (q != null)
            {
                jobs = _context.Jobs.Where(job => job.Name.Contains(q)).OrderByDescending(j => j.Id).ToList();
                return View(jobs);
            }

            jobs = await _context.Jobs.OrderByDescending(j => j.Id).ToListAsync();
            return View(jobs);
        }

    }
}