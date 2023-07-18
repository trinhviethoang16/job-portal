using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobPortal.Data.DataContext;
using X.PagedList;

namespace JobPortal.WebApp.Controllers
{
    [Route("blog")]
    public class BlogController : Controller
    {
        private readonly DataDbContext _context;

        public BlogController(DataDbContext context)
        {
            _context = context;
        }

        [Route("")]
        public IActionResult Index(int? page)
        {
            int pageSize = 3; //number of blogs per page
			var random = new Random();

			//random jobs - 6
			var jobList = _context.Jobs
				.Include(j => j.Province)
				.Include(j => j.AppUser)
				.Include(j => j.Title)
				.Include(j => j.Time)
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

            var blogs = _context.Blogs
                .OrderByDescending(j => j.Popular)
                .Include(j => j.AppUser)
                .ToList();

            int pageNumber = page ?? 1; // Trang hiện tại
            ViewBag.StartRank = (pageNumber - 1) * pageSize + 1; // Xếp hạng bắt đầu của blogs trên trang hiện tại

            return View(blogs.ToPagedList(pageNumber, pageSize));
        }

        [Route("{slug}")]
        public async Task<IActionResult> Detail(string slug)
        {
			var random = new Random();

			//random jobs - 6
			var jobList = _context.Jobs
                .Include(j => j.Province)
                .Include(j => j.AppUser)
                .Include(j => j.Title)
				.Include(j => j.Time)
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

            var blog = await _context.Blogs
                .Where(j => j.Slug == slug)
                .Include(j => j.AppUser)
                .FirstOrDefaultAsync();
            blog.Popular++;
            await _context.SaveChangesAsync();

            return View(blog);
        }
    }
}