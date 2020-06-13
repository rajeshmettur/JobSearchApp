using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobSearchApp.DataAccess.Data;
using JobSearchApp.Models;
using System.Security.Claims;

namespace JobSearchApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class JobApplicationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobApplicationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/JobApplications
        public async Task<IActionResult> Index()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var applicationDbContext = _context.JobApplication.Include(j => j.AppUser).Include(j => j.JobEntity)
                                        .Where(x => x.UserId == claim.Value);
            return View(await applicationDbContext.ToListAsync());
        }


        private bool JobApplicationExists(Guid id)
        {
            return _context.JobApplication.Any(e => e.Id == id);
        }
    }
}
