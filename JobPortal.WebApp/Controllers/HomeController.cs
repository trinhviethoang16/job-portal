using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobPortal.Data.DataContext;
using JobPortal.Data.Entities;
using JobPortal.WebApp.Models;
using System.Diagnostics;

namespace JobPortal.WebApp.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly DataDbContext _context;

        public HomeController(ILogger<HomeController> logger, DataDbContext context)
        {
            
            _context = context;
        }

        public IActionResult Index()
        {
            List<Job> jobList = _context.Jobs.ToList();
            return View(jobList);
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Category()
        {
            return View();
        }

        public IActionResult Price()
        {
            return View();
        }

        public IActionResult BlogHome()
        {
            return View();
        }

        public IActionResult BlogSingle()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Elements()
        {
            return View();
        }

        public IActionResult Search()
        {
            return View();
        }
        public IActionResult Single()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}