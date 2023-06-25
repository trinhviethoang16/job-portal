using Microsoft.AspNetCore.Mvc;
using JobPortal.Data.DataContext;
using JobPortal.Data.Entities;
using JobPortal.Data.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using X.PagedList;

namespace JobPortal.WebApp.Areas.Employer.Controllers
{
    [Area("Employer")]
    [Route("employer")]
    [Authorize(Roles = "Employer")]
    public class HomeController : Controller
    {
        private readonly DataDbContext _context;

        public HomeController(DataDbContext context)
        {
            _context = context;
        }

        [Route("index/{id}")]
        [Route("{id}")]
        public IActionResult Index(Guid id, int? page)
        {
            int pageSize = 5; //number of item per page

            var jobs = _context.Jobs
                .Where(j => j.AppUserId == id)
                .OrderByDescending(j => j.CreateDate)
                .Include(j => j.AppUser)
                .Include(j => j.Title)
                .Include(j => j.Time)
                .Include(j => j.Province)
                .ToList();

            //cv count
            var cvCount = _context.CVs.Where(cv => cv.AppUserId == id).Count();
            ViewBag.cvCount = cvCount;

            //cv list
            var cvList = _context.CVs
                .Where(cv => cv.AppUserId == id)
                .OrderByDescending(cv => cv.EmployerRating)
                .Include(cv => cv.AppUser)
                .Take(4)
                .ToList();
            ViewBag.cvList = cvList;

            //blog count
            //var blogCount = _context.Blogs.Count();
            //ViewBag.blogCount = blogCount;

            //blog list
            //ViewBag.Blogs = _context.Blogs.OrderByDescending(b => b.Id).Include(b => b.AppUser).ToList();

            return View(jobs.ToPagedList(page ?? 1, pageSize));
        }
    }
}
