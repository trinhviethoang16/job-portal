using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobPortal.Data.DataContext;
using JobPortal.Data.Entities;
using Microsoft.Build.Framework;

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
        public async Task<IActionResult> Index(string q, int province, int skill)
        {
			//for random value
			var random = new Random();

            //For search filter area
            ViewBag.FilterProvinces = _context.Provinces.OrderBy(p => p.Id).ToList();
            ViewBag.FilterSkills = _context.Skills.OrderBy(s => s.Id).ToList();

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
            ViewBag.province = await _context.Provinces.FirstOrDefaultAsync(p => p.Id == province);
            ViewBag.skill = await _context.Skills.FirstOrDefaultAsync(s => s.Id == skill);


            var jobs = await _context.Jobs.OrderByDescending(j => j.Id).Include(j => j.AppUser).ToListAsync();

            if (!string.IsNullOrEmpty(q))
            {
                jobs = _context.Jobs.Where(job => job.Name.Contains(q)).OrderByDescending(j => j.Id).ToList();

                if (province != 0)
                {
                    jobs = jobs.Where(job => job.ProvinceId == province).ToList();
                }

                if (skill != 0)
                {
                    jobs = jobs.Where(job => job.SkillId == skill).ToList();
                }

                return View(jobs);
            }
            else
            {
                if (province != 0)
                {
                    jobs = jobs.Where(job => job.ProvinceId == province).ToList();
                }

                if (skill != 0)
                {
                    jobs = jobs.Where(job => job.SkillId == skill).ToList();
                }

                return View(jobs);
            }
        }
    }
}