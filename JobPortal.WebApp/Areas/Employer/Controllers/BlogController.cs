    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using JobPortal.Data.DataContext;
using JobPortal.Data.Entities;
using JobPortal.Data.ViewModel;
using JobPortal.Common;
using Microsoft.AspNetCore.Identity;

namespace JobPortal.WebApp.Areas.Employer.Controllers
{
    [Area("Employer")]
    [Route("employer/blog")]
    [Authorize(Roles = "Employer")]
    public class BlogController : Controller
    {
        private readonly DataDbContext _context;

        public BlogController(DataDbContext context)
        {
            _context = context;
        }
    }
}