using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobPortal.Data.DataContext;
using JobPortal.Data.Entities;
using System;
using Microsoft.AspNetCore.Identity;

namespace JobPortal.WebApp.Controllers
{
    [Route("job")]
    public class JobController : Controller
    {
        private readonly DataDbContext _context;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public JobController(DataDbContext context, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [Route("")]
        public async Task<IActionResult> Index(string slug)
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

            //random provinces - 5
            var provinceList = _context.Provinces.ToList();
            var randomProvinces = provinceList.OrderBy(p => random.Next()).Take(5).ToList();
            ViewBag.ListProvinces = randomProvinces;


            ViewBag.ListTimes = _context.Times.OrderBy(t => t.Id).ToList();
            var jobs = await _context.Jobs.OrderByDescending(j => j.Id).Include(j => j.AppUser).ToListAsync();

            if (slug != null)
            {
                var time = _context.Times.FirstOrDefault(t => t.Slug == slug);
                var province = _context.Provinces.FirstOrDefault(p => p.Slug == slug);
                var skill = _context.Skills.FirstOrDefault(s => s.Slug == slug);
                var employer = _context.AppUsers.FirstOrDefault(e => e.Slug == slug);

                if (time != null)
                {
                    jobs = await (from t in _context.Times
                                  join job in _context.Jobs on t.Id equals job.TimeId
                                  orderby job.Id descending
                                  where t.Slug == slug
                                  select job).ToListAsync();
                    ViewBag.Time = time;
                }
                else if (province != null)
                {
                    jobs = await (from p in _context.Provinces
                                  join job in _context.Jobs on p.Id equals job.ProvinceId
                                  orderby job.Id descending
                                  where p.Slug == slug
                                  select job).ToListAsync();
                    ViewBag.Province = province;
                }
                else if (skill != null)
                {
                    jobs = await (from s in _context.Skills
                                  join job in _context.Jobs on s.Id equals job.SkillId
                                  orderby job.Id descending
                                  where s.Slug == slug
                                  select job).ToListAsync();
                    ViewBag.Skill = skill;
                }
                else if (employer != null)
                {
                    jobs = await (from e in _context.AppUsers
                                  join job in _context.Jobs on e.Id equals job.AppUserId
                                  orderby job.Id descending
                                  where e.Slug == slug
                                  select job).ToListAsync();
                    ViewBag.Employer = employer;
                }
                else
                {
                    jobs = await _context.Jobs.OrderByDescending(j => j.Id)
                        .Include(j => j.AppUser)
                        .ToListAsync();
                }

                return View(jobs);
            }
            jobs = await _context.Jobs.OrderByDescending(j => j.Id)
                .Include(j => j.AppUser)
                .ToListAsync();
            return View(jobs);
        }

        [Route("{slug}")]
        public async Task<IActionResult> Detail(string slug)
        {
            //for random value
            var random = new Random();

            //random skills - 10
            var skillList = _context.Skills.ToList();
            var randomSkills = skillList.OrderBy(s => random.Next()).Take(10).ToList();
            ViewBag.ListSkills = randomSkills;

            //random provinces - 5
            var provinceList = _context.Provinces.ToList();
            var randomProvinces = provinceList.OrderBy(p => random.Next()).Take(5).ToList();
            ViewBag.ListProvinces = randomProvinces;

            var job = await _context.Jobs
                .Where(j => j.Slug == slug)
                .Include(j => j.AppUser)
                .Include(j => j.Time)
                .FirstOrDefaultAsync();

            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;
            var hasSubmittedCV = userId != Guid.Empty ? await HasSubmittedCV(userId, slug) : false;

            ViewBag.HasSubmittedCV = hasSubmittedCV;

            return View(job);
        }

        private async Task<bool> HasSubmittedCV(Guid userId, string jobSlug)
        {
            return await _context.CVs.AnyAsync(cv => cv.Job.Slug == jobSlug && cv.AppUserId == userId);
        }

    }
}