﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using JobPortal.Data.DataContext;
using JobPortal.Data.Entities;
using JobPortal.Data.ViewModel;
using X.PagedList;
using System;
using System.Linq;

namespace JobPortal.WebApp.Areas.Admin.Controllers

{
    [Area("Admin")]
    [Route("admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly DataDbContext _context;

        public HomeController(DataDbContext context)
        {
            _context = context;
        }

        [Route("index")]
        [Route("")]
        public IActionResult Index()
        {
            //employer count
            var employerCount = _context.AppUsers.Count(e => e.Status == 2);
            ViewBag.CountEmployer = employerCount;

            //user count
            var userCount = _context.AppUsers.Count(e => e.Status == 1);
            ViewBag.CountUser = userCount;

            //job count
            var jobCount = _context.Jobs.Count();
            ViewBag.CountJob = jobCount;
            return View();
        }

        [Route("list-employer")]
        public IActionResult ListEmployer(int? page)
        {
            int pageSize = 5;
            var employers = _context.AppUsers.OrderByDescending(e => e.Id).Where(e => e.Status == 2).ToList();
            return View(employers.ToPagedList(page ?? 1, pageSize));
        }


        [Route("list-user")]
        public IActionResult ListUser(int? page)
        {
            int pageSize = 5;
            var users = _context.AppUsers.OrderByDescending(u => u.Id).Where(u => u.Status == 1).ToList();
            return View(users.ToPagedList(page ?? 1, pageSize));
        }
    }
}