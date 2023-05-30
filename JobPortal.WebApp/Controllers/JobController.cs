using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobPortal.Data.DataContext;
using JobPortal.Data.Entities;
using System;

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
			//for random value
			var random = new Random();

			//random jobs - 6
			var jobList = _context.Jobs.Include(j => j.Province).ToList();
			var randomJobs = jobList.OrderBy(j => random.Next()).Take(6).ToList();
			ViewBag.ListJobs = randomJobs;

			//random skills - 10
			var skillList = _context.Skills.ToList();
			var randomSkills = skillList.OrderBy(s => random.Next()).Take(10).ToList();
			ViewBag.ListSkills = randomSkills;

            ViewBag.ListProvinces = _context.Provinces.OrderBy(p => p.Id).ToList();
            ViewBag.ListTimes = _context.Times.OrderBy(t => t.Id).ToList();

            var jobs = await _context.Jobs.OrderByDescending(j => j.Id).Include(j => j.AppUser).ToListAsync();
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
            jobs = await _context.Jobs.OrderByDescending(j => j.Id).Include(j => j.AppUser).ToListAsync();
            return View(jobs);
        }

        [Route("{slug}")]
        public async Task<IActionResult> Detail(string slug)
        {
            ViewBag.ListJobs = _context.Jobs.OrderBy(p => p.Id).Take(6).ToList();
            ViewBag.ListSkills = _context.Skills.OrderBy(s => s.Id).Take(10).ToList();
            ViewBag.ListProvinces = _context.Provinces.OrderBy(p => p.Id).ToList();
            ViewBag.ListTimes = _context.Times.OrderBy(t => t.Id).ToList();
            var job = await _context.Jobs.Where(j => j.Slug == slug).Include(j => j.AppUser).FirstOrDefaultAsync();
            return View(job);
        }
    }
}