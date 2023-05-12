using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobPortal.Data.DataContext;
using JobPortal.Data.Entities;

namespace JobPortal.WebApp.Controllers
{
    public class JobController : Controller
    {
        private readonly DataDbContext _context;

        public JobController(DataDbContext context)
        {
            _context = context;
        }

        public IActionResult JobList()
        {
            List<Job> jobList = _context.Jobs.ToList();
            return View(jobList);
        }
        public IActionResult PopularList()
        {
            List<Job> jobList = _context.Jobs.ToList();
            return View(jobList);
        }

        public IActionResult Detail(int id)
        {
            Job job = _context.Jobs.Where(x => x.Id == id).FirstOrDefault();
            return View(job);
        }

        public IActionResult Category(int id)
        {
            ViewBag.CategoryName = _context.Categories.FirstOrDefault(x => id == x.Id).Name;
            List<Job> jobs = _context.Jobs.Where(x => x.Category.Id == id).ToList();
            return View(jobs);
        }
    }
}
