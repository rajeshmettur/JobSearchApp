using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JobSearchApp.DataAccess;
using JobSearchApp.Models;
using JobSearchApp.Models.ViewModel;
using JobSearchApp.DataAccess.Data;
using SQLitePCL;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace JobSearchApp.Areas.JobSearch.Controllers
{
    [Area("JobSearch")]
    public class HomeController : Controller
    {

        [BindProperty]
        public string SearchString { get; set; }

        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            string title = string.Empty;

            if (Request.QueryString != null)
                title = HttpContext.Request.Query["SearchString"];

                IndexViewModel IndexVM = new IndexViewModel()
                {
                    JobList = await _context.Job.Include(x => x.Company).AsNoTracking()
                                    .Where(x => 
                                    (
                                        (string.IsNullOrEmpty(title) || x.Title.ToLower().StartsWith(title.ToLower()))
                                        || (string.IsNullOrEmpty(title) || x.Company.Name.StartsWith(title.ToLower()))
                                    )).ToListAsync(),
                    TechnologyList = await _context.Technology.Where(c => c.IsActive == true).ToListAsync(),
                    CompanyList = await _context.Company.ToListAsync(),
                    ApplicationList = await _context.JobApplication.ToListAsync()
                };

            return View(IndexVM);
        }

        [Authorize]
        public async Task<IActionResult> Details(Guid? id, JobApplication jobapp)
        {
            if (id == null)
            {
                return NotFound();
            }
           

            var job = await _context.Job.FirstOrDefaultAsync(m => m.Id == id);
            if (job == null)
            {
                return NotFound();
            }
           
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var isApplied = await _context.JobApplication.SingleOrDefaultAsync(m => m.Id == job.Id && m.UserId == claim.Value);
            
            if(isApplied != null)
            {
                TempData["msg"] = "<script>alert('Job Applied Already');</script>";
                return NoContent();
            }

            jobapp.Id = Guid.NewGuid();
            jobapp.JobId = job.Id;
            jobapp.UserId = claim.Value;

            _context.Add(jobapp);
            await _context.SaveChangesAsync();

            return Redirect("~/Admin/JobApplications");

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