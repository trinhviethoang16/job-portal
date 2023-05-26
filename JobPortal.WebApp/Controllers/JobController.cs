using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobPortal.Data.DataContext;
using JobPortal.Data.Entities;

namespace JobPortal.WebApp.Controllers
{
    [Route("job")]
    public class JobController : Controller
    {
        private readonly DataDbContext _context;

        public JobController(DataDbContext context)
        {
            _context = context;
        }

        //Job list by time
        [Route("")]
        public async Task<IActionResult> Index(string timelog)
        {
            ViewBag.ListJobs = _context.Jobs.OrderBy(p => p.Id).Take(6).ToList();
            ViewBag.ListSkills = _context.Skills.OrderBy(s => s.Id).Take(10).ToList();
            ViewBag.ListProvinces = _context.Provinces.OrderBy(p => p.Id).ToList();
            ViewBag.ListTimes = _context.Times.OrderBy(t => t.Id).ToList();

            var jobs = await _context.Jobs.OrderByDescending(j => j.Id).ToListAsync();
            if (timelog != null)
            {
                ViewBag.Time = _context.Times.FirstOrDefault(t => t.Slug == timelog);

                jobs = await (from t in _context.Times
                              join job in _context.Jobs on t.Id equals job.TimeId
                              orderby job.Id descending
                              where t.Slug == timelog
                              select job).ToListAsync();
                return View(jobs);
            }
            jobs = await _context.Jobs.OrderByDescending(j => j.Id).ToListAsync();
            return View(jobs);
        }

        [Route("{slug}")]
        public async Task<IActionResult> Detail(string slug)
        {
            ViewBag.ListJobs = _context.Jobs.OrderBy(p => p.Id).Take(6).ToList();
            ViewBag.ListSkills = _context.Skills.OrderBy(s => s.Id).Take(10).ToList();
            ViewBag.ListProvinces = _context.Provinces.OrderBy(p => p.Id).ToList();
            ViewBag.ListTimes = _context.Times.OrderBy(t => t.Id).ToList();
            var job = await _context.Jobs.Where(p => p.Slug == slug).FirstOrDefaultAsync();
            return View(job);
        }
    }
}