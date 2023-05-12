using Microsoft.AspNetCore.Mvc;
using JobPortal.Data.DataContext;
using JobPortal.Data.Entities;
using JobPortal.Data.ViewModel;

namespace JobPortal.WebApp.Areas.Employer.Controllers
{
    [Area("Employer")]
    [Route("employer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataDbContext _context;

        public HomeController(ILogger<HomeController> logger, DataDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [Route("index")]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }


        [Route("blog-home")]
        public IActionResult BlogHome()
        {
            return View();
        }

        [Route("category")]
        public IActionResult Category()
        {
            return View();
        }


        [Route("blog-single")]
        public IActionResult BlogSingle()
        {
            return View();
        }
    }
}
