using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobPortal.Data.DataContext;
using JobPortal.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using JobPortal.Data.ViewModel;
using JobPortal.Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Principal;

namespace JobPortal.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/apply-employer")]
    [Authorize(Roles = "Admin")]
    public class EmployerController : Controller
    {
        private readonly DataDbContext _context;

        public EmployerController(DataDbContext context)
        {
            _context = context;
        }

        [Route("index/{status}")]
        [Route("{status}")]
        public async Task<IActionResult> Index(int status)
        {
            var user = (from employer in _context.AppUsers
                        orderby employer.Id descending
                        select new UpdateEmployerViewModel()
                        {
                            FullName = employer.FullName,
                            Description = employer.Description,
                            Contact = employer.Contact,
                            Location = employer.Location,
                            WebsiteURL = employer.WebsiteURL,
                            Status = employer.Status
                        });
            var users = await user.ToListAsync();
            switch (status)
            {
                case 0:
                    users = await user.Where(p => p.Status == 0).ToListAsync();
                    break;
                case 1:
                    users = await user.Where(p => p.Status == 1).ToListAsync();
                    break;
                case 2:
                    users = await user.Where(p => p.Status == 2).ToListAsync();
                    break;
                case 3:
                    users = await user.Where(p => p.Status == 3).ToListAsync();
                    break;
                case 4:
                    users = await user.Where(p => p.Status == 4).ToListAsync();
                    break;
                case 5:
                    users = await user.ToListAsync();
                    break;
                default:
                    users = await user.ToListAsync();
                    break;
            }

            return View(users);
        }

        [Route("update-user-status/{Id}/{status}")]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> UpdateStatus(Guid Id, int status)
        {
            var user = await _context.AppUsers.FirstOrDefaultAsync(user => user.Id == Id);
            user.Status = status;
            _context.AppUsers.Update(user);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}