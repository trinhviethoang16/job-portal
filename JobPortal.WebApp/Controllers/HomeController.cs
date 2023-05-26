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
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, DataDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.ListCategories = _context.Categories.OrderBy(c => c.Id).Take(6).ToList();
            ViewBag.ListSkills = _context.Skills.OrderBy(s => s.Id).Take(6).ToList();
            ViewBag.ListJobs = _context.Jobs.OrderBy(j => j.Id).Take(6).ToList();
            //Tam thoi de yen nhu z
            ViewBag.ListEmployers = _context.Users.OrderBy(u => u.Id).Take(4).ToList();
            return View();
        }

        [Route("about-us")]
        public IActionResult AboutUs()
        {
            return View();
        }

        [Route("price")]
        public IActionResult Price()
        {
            return View();
        }

        [Route("blog")]
        public IActionResult Blog()
        {
            return View();
        }

        [Route("contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [Route("elements")]
        public IActionResult Elements()
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