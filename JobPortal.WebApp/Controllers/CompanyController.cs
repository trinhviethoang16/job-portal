using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobPortal.Data.DataContext;
using X.PagedList;

namespace JobPortal.WebApp.Controllers
{
    [Route("company")]
    public class CompanyController : Controller
    {
        private readonly DataDbContext _context;

        public CompanyController(DataDbContext context)
        {
            _context = context;
        }

        [Route("")]
        public IActionResult Index(int? page)
        {
            int pageSize = 7; //number of employers per page
            var random = new Random();

            //random jobs - 6
            var jobList = _context.Jobs
                .Include(j => j.Province)
                .Include(j => j.Time)
                .Include(j => j.Title)
                .Include(j => j.AppUser)
                .ToList();
            ViewBag.ListJobs = jobList.OrderBy(j => random.Next()).Take(6).ToList();

            //random skills - 7
            var skillList = _context.Skills.Include(s => s.Jobs).ToList();
            ViewBag.ListSkills = skillList.OrderBy(s => random.Next()).Where(s => s.Jobs.Count > 0).Take(7).ToList();

            //provinces - 4
            ViewBag.ListProvinces = _context.Provinces.Include(p => p.Jobs).Where(p => p.Jobs.Count > 0).Take(4).ToList();

            //random blogs - 5
            var blogList = _context.Blogs.Include(b => b.AppUser).ToList();
            ViewBag.ListBlogs = blogList.OrderBy(s => random.Next()).Take(5).ToList();

            var employers = _context.AppUsers
                .Where(e => e.Status == 2)
                .OrderByDescending(e => e.Popular)
                .Include(e => e.Province)
                .Include(e => e.Country)
                .ToList();

            int pageNumber = page ?? 1; // Trang hiện tại
            ViewBag.StartRank = (pageNumber - 1) * pageSize + 1; // Xếp hạng bắt đầu của employers trên trang hiện tại

            return View(employers.ToPagedList(pageNumber, pageSize));

        }

        [Route("{slug}")]
        public async Task<IActionResult> Detail(string slug)
        {
            var random = new Random();

            //random jobs - 6
            var jobList = _context.Jobs
                .Include(j => j.Province)
                .Include(j => j.Time)
                .Include(j => j.Title)
                .Include(j => j.AppUser)
                .ToList();
            ViewBag.ListJobs = jobList.OrderBy(j => random.Next()).Take(6).ToList();

            //random skills - 7
            var skillList = _context.Skills.Include(s => s.Jobs).ToList();
            ViewBag.ListSkills = skillList.OrderBy(s => random.Next()).Where(s => s.Jobs.Count > 0).Take(7).ToList();

            //provinces - 4
            ViewBag.ListProvinces = _context.Provinces.Include(p => p.Jobs).Where(p => p.Jobs.Count > 0).Take(4).ToList();

            //random blogs - 5
            var blogList = _context.Blogs.Include(b => b.AppUser).ToList();
            ViewBag.ListBlogs = blogList.OrderBy(s => random.Next()).Take(5).ToList();

            //job count
            var jobCount = _context.Jobs.Where(j => j.AppUser.Slug == slug).Count();
            ViewBag.CountJob = jobCount;

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