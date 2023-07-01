using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobPortal.Data.DataContext;
using JobPortal.Data.Entities;
using System;
using Microsoft.AspNetCore.Identity;
using X.PagedList;

namespace JobPortal.WebApp.Controllers
{
    [Route("company")]
    public class CompanyController : Controller
    {
        private readonly DataDbContext _context;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public CompanyController(DataDbContext context, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [Route("")]
        public IActionResult Index(int? page)
        {
            int pageSize = 5; //number of employers per page

            //for random value
            var random = new Random();

            //random jobs - 6
            var jobList = _context.Jobs.Include(j => j.Province).Include(j => j.Time).Include(j => j.Title).Include(j => j.AppUser).ToList();
            ViewBag.ListJobs = jobList.OrderBy(j => random.Next()).Take(6).ToList();

            //random skills - 7
            var skillList = _context.Skills.Include(s => s.Jobs).ToList();
            ViewBag.ListSkills = skillList.OrderBy(s => random.Next()).Where(s => s.Jobs.Count > 0).Take(7).ToList();

            //provinces - 4
            ViewBag.ListProvinces = _context.Provinces.Include(p => p.Jobs).Where(p => p.Jobs.Count > 0).Take(4).ToList();

            var employers = _context.AppUsers
                .Where(e => e.Status == 2)
                .OrderByDescending(e => e.Popular)
                .Include(e => e.Province)
                .Include(e => e.Country)
                .ToList();

            return View(employers.ToPagedList(page ?? 1, pageSize));
        }

        [Route("{slug}")]
        public async Task<IActionResult> Detail(string slug)
        {
            //for random value
            var random = new Random();

            //random jobs - 6
            var jobList = _context.Jobs.Include(j => j.Province).Include(j => j.Time).Include(j => j.Title).Include(j => j.AppUser).ToList();
            ViewBag.ListJobs = jobList.OrderBy(j => random.Next()).Take(6).ToList();

            //random skills - 7
            var skillList = _context.Skills.Include(s => s.Jobs).ToList();
            ViewBag.ListSkills = skillList.OrderBy(s => random.Next()).Where(s => s.Jobs.Count > 0).Take(7).ToList();

            //provinces - 4
            ViewBag.ListProvinces = _context.Provinces.Include(p => p.Jobs).Where(p => p.Jobs.Count > 0).Take(4).ToList();

            var employer = await _context.AppUsers
                .Where(e => e.Slug == slug)
                .Include(e => e.Province)
                .Include(e => e.Country)
                .FirstOrDefaultAsync();
            employer.Popular++;
            await _context.SaveChangesAsync();

            return View(employer);
        }
    }
}