using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using JobPortal.Data.Entities;
using JobPortal.Data.ViewModel;
using System;
using JobPortal.Data.DataContext;

namespace JobPortal.WebApp.Areas.Employer.Controllers
{
    [Area("Employer")]
    [Route("employer/applicant")]
    public class ApplicantController : Controller
    {
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}