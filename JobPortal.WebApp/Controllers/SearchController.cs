using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobPortal.Data.DataContext;

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
            var random = new Random();

            //For search filter area
            ViewBag.FilterProvinces = _context.Provinces.OrderBy(p => p.Id).ToList();
            ViewBag.FilterSkills = _context.Skills.OrderBy(s => s.Name).ToList();

            //random jobs - 6
            var jobList = _context.Jobs.Include(j => j.Province).ToList();
            ViewBag.ListJobs = jobList.OrderBy(j => random.Next()).Take(6).ToList();

            //random skills - 7
            var skillList = _context.Skills.Include(s => s.Jobs).ToList();
            ViewBag.ListSkills = skillList.OrderBy(s => random.Next()).Take(7).ToList();

            //provinces - 4
            ViewBag.ListProvinces = _context.Provinces.Include(p => p.Jobs).Where(p => p.Jobs.Count > 0).Take(4).ToList();

            //random blogs - 5
            var blogList = _context.Blogs.Include(b => b.AppUser).ToList();
            ViewBag.ListBlogs = blogList.OrderBy(s => random.Next()).Take(5).ToList();

            ViewBag.q = q;
            ViewBag.province = await _context.Provinces.FirstOrDefaultAsync(p => p.Id == province);
            ViewBag.skill = await _context.Skills.FirstOrDefaultAsync(s => s.Id == skill);

            //set selected values for dropdowns
            ViewBag.SelectedProvinceId = province;
            ViewBag.SelectedSkillId = skill;

            var jobs = await _context.Jobs
                .OrderByDescending(j => j.Id)
                .Include(j => j.AppUser)
                .Include(j => j.Title)
                .Include(j => j.Time)
                .Include(j => j.Skills)
                .ToListAsync();

            if (!string.IsNullOrEmpty(q))
            {
                jobs = _context.Jobs.Where(job => job.Name.Contains(q)).OrderByDescending(j => j.Id).ToList();

                if (province != 0)
                {
                    jobs = jobs.Where(job => job.ProvinceId == province).ToList();
                }

                if (skill != 0)
                {
                    jobs = jobs.Where(job => job.Skills.Any(s => s.Id == skill)).ToList();
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
                    jobs = jobs.Where(job => job.Skills.Any(s => s.Id == skill)).ToList();
                }

                return View(jobs);
            }
        }
    }
}