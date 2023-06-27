using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobPortal.Data.DataContext;
using JobPortal.Data.Entities;
using System;
using Microsoft.AspNetCore.Identity;
using X.PagedList;

namespace JobPortal.WebApp.Controllers
{
    [Route("blog")]
    public class BlogController : Controller
    {
        private readonly DataDbContext _context;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public BlogController(DataDbContext context, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [Route("")]
        public IActionResult Index(int? page)
        {
            int pageSize = 5; //number of jobs per page

            //for random value
            var random = new Random();

            //random jobs - 6
            var jobList = _context.Jobs.Include(j => j.Province).ToList();
            ViewBag.ListJobs = jobList.OrderBy(j => random.Next()).Take(6).ToList();

            //random skills - 7
            var skillList = _context.Skills.Include(s => s.Jobs).ToList();
            ViewBag.ListSkills = skillList.OrderBy(s => random.Next()).Where(s => s.Jobs.Count > 0).Take(7).ToList();

            //random provinces - 5
            var provinceList = _context.Provinces.Include(p => p.Jobs).ToList();
            ViewBag.ListProvinces = provinceList.OrderBy(p => random.Next()).Where(p => p.Jobs.Count > 0).Take(5).ToList();

            var blogs = _context.Blogs
                .OrderByDescending(b => b.CreateDate)
                .Include(b => b.AppUser)
                .ToList();
            
            return View(blogs.ToPagedList(page ?? 1, pageSize));
        }

        [Route("blog/{slug}")]
        public async Task<IActionResult> Detail(string slug)
        {
            //for random value
            var random = new Random();

            //random jobs - 6
            var jobList = _context.Jobs.Include(j => j.Province).ToList();
            ViewBag.ListJobs = jobList.OrderBy(j => random.Next()).Take(6).ToList();

            //random skills - 7
            var skillList = _context.Skills.Include(s => s.Jobs).ToList();
            ViewBag.ListSkills = skillList.OrderBy(s => random.Next()).Take(7).ToList();

            //random provinces - 4
            var provinceList = _context.Provinces.Include(p => p.Jobs).ToList();
            ViewBag.ListProvinces = provinceList.OrderBy(p => random.Next()).Take(4).ToList();

            var blog = await _context.Blogs
                .Where(b => b.Slug == slug)
                .Include(j => j.AppUser)
                .FirstOrDefaultAsync();

            return View(blog);
        }
    }
}