using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobPortal.Data.DataContext;
using JobPortal.Data.Entities;
using Microsoft.AspNetCore.Identity;
using JobPortal.Data.ViewModel;
using X.PagedList;

namespace JobPortal.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/apply-employer")]
    public class EmployerController : Controller
    {
        private readonly DataDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public EmployerController(DataDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Route("index/{status}")]
        [Route("{status}")]
        public async Task<IActionResult> Index(int status, int? page)
        {
            int pageSize = 5; //number of users per page

            var employer = (from emp in _context.AppUsers
                        orderby emp.CreateDate descending
                        select new ListEmployersViewWModel()
                        {
                            Id = emp.Id,
                            FullName = emp.FullName,
                            Description = emp.Description,
                            Contact = emp.Contact,
                            Location = emp.Location,
                            WebsiteURL = emp.WebsiteURL,
                            UrlAvatar = emp.UrlAvatar,
                            RegisterDate = emp.CreateDate,
                            ProvinceName = emp.Province.Name,
                            Status = emp.Status
                        });
            var employers = await employer.ToListAsync();
            switch (status)
            {
                case 0: // denied
                    employers = await employer.Where(p => p.Status == 0).ToListAsync();
                    break;
                case 1: // pending
                    employers = await employer.Where(p => p.Status == 1).ToListAsync();
                    break;
                case 2: // confirmed
                    employers = await employer.Where(p => p.Status == 2).ToListAsync();
                    break;
                case 3: // all but admin & newly created account
                    employers = await employer.Where(p => p.Status != null && p.Status != -1).ToListAsync();
                    break;
                default:
                    employers = await employer.Where(p => p.Status != null && p.Status != -1).ToListAsync();
                    break;
            }
            return View(employers.ToPagedList(page ?? 1, pageSize));
        }

        [Route("update-employer-status/{id}/{status}")]
        [HttpGet]
        public async Task<IActionResult> UpdateStatus(Guid id, int status)
        {
            var employer = await _context.AppUsers.FirstOrDefaultAsync(user => user.Id == id);
            employer.Status = status;
            _context.AppUsers.Update(employer);
            await _context.SaveChangesAsync();

            //get id and check 
            var user = await _userManager.FindByIdAsync(id.ToString());
            //get role by id
            var role = await _userManager.GetRolesAsync(user);

            //Check status to set role
            if (status == 0) //denied
            {
                if (await _userManager.IsInRoleAsync(user, "Employer"))
                {
                    await _userManager.RemoveFromRoleAsync(user, "Employer");
                    await _userManager.AddToRoleAsync(user, "User");
                }
            }
            else if (status == 2) //confirmed
            {
                await _userManager.RemoveFromRoleAsync(user, "User");
                await _userManager.AddToRoleAsync(user, "Employer");
            }
            return Redirect("/admin/apply-employer/" + status);
        }
    }
}