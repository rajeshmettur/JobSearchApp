using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobSearchApp.DataAccess.Data;
using JobSearchApp.Models;
using JobSearchApp.Models.ViewModel;
using JobSearchApp.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace JobSearchApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class JobEntitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IWebHostEnvironment _hostEnvironment;

        [BindProperty]
        public JobViewModel JobVM { get; set; }
        public JobEntitiesController(ApplicationDbContext context, IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Admin/JobEntities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Job.Include(x => x.Company).ToListAsync());
        }

        // GET: Admin/JobEntities/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobEntity = await _context.Job
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobEntity == null)
            {
                return NotFound();
            }

            return View(jobEntity);
        }

        // GET: Admin/JobEntities/Create
        public IActionResult Create()
        {
            JobVM = new JobViewModel
            {
                CompanyList = _unitOfWork.Company.GetCompanyLists(),
                JobEntity = new JobEntity()
            };
            return View(JobVM);
        }

        // POST: Admin/JobEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Salary,Location,CompanyId,Time")] JobEntity jobEntity)
        {
            if (ModelState.IsValid)
            {
                jobEntity.Id = Guid.NewGuid();
                _context.Add(jobEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jobEntity);
        }

        // GET: Admin/JobEntities/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobEntity = await _context.Job.FindAsync(id);
            if (jobEntity == null)
            {
                return NotFound();
            }
            return View(jobEntity);
        }

        // POST: Admin/JobEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,Description,Salary,Location,CompanyId,Time")] JobEntity jobEntity)
        {
            if (id != jobEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobEntityExists(jobEntity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(jobEntity);
        }

        // GET: Admin/JobEntities/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobEntity = await _context.Job
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobEntity == null)
            {
                return NotFound();
            }

            return View(jobEntity);
        }

        // POST: Admin/JobEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var jobEntity = await _context.Job.FindAsync(id);
            _context.Job.Remove(jobEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobEntityExists(Guid id)
        {
            return _context.Job.Any(e => e.Id == id);
        }
    }
}
