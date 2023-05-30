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

            ViewBag.q = q;
            var jobs = await _context.Jobs.OrderByDescending(j => j.Id).Include(j => j.AppUser).ToListAsync();

            if (q != null)
            {
                jobs = _context.Jobs.Where(job => job.Name.Contains(q)).OrderByDescending(j => j.Id).ToList();
                return View(jobs);
            }

            jobs = await _context.Jobs.OrderByDescending(j => j.Id).Include(j => j.AppUser).ToListAsync();
            return View(jobs);
        }

    }
}