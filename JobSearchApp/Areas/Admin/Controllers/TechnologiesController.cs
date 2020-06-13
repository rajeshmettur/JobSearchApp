using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobSearchApp.DataAccess.Data;
using JobSearchApp.Models;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace JobSearchApp.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class TechnologiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TechnologiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Technologies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Technology.ToListAsync());
        }

        // GET: Admin/Technologies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var technology = await _context.Technology
                .FirstOrDefaultAsync(m => m.Id == id);
            if (technology == null)
            {
                return NotFound();
            }

            return View(technology);
        }

        // GET: Admin/Technologies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Technologies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Picture,IsActive")] Technology technology)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    byte[] p1 = null;
                    using (var fs1 = files[0].OpenReadStream())
                    {
                        using (var ms1 = new MemoryStream())
                        {
                            fs1.CopyTo(ms1);
                            p1 = ms1.ToArray();
                        }
                    }
                    technology.Picture = p1;
                }
                _context.Add(technology);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(technology);
        }

        // GET: Admin/Technologies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var technology = await _context.Technology.FindAsync(id);
            if (technology == null)
            {
                return NotFound();
            }
            return View(technology);
        }

        // POST: Admin/Technologies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Picture,IsActive")] Technology technology)
        {
            if (id != technology.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var files = HttpContext.Request.Form.Files;
                    if (files.Count > 0)
                    {
                        byte[] p1 = null;
                        using (var fs1 = files[0].OpenReadStream())
                        {
                            using (var ms1 = new MemoryStream())
                            {
                                fs1.CopyTo(ms1);
                                p1 = ms1.ToArray();
                            }
                        }
                        technology.Picture = p1;
                    }
                    _context.Update(technology);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TechnologyExists(technology.Id))
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
            return View(technology);
        }

        // GET: Admin/Technologies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var technology = await _context.Technology
                .FirstOrDefaultAsync(m => m.Id == id);
            if (technology == null)
            {
                return NotFound();
            }

            return View(technology);
        }

        // POST: Admin/Technologies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var technology = await _context.Technology.FindAsync(id);
            _context.Technology.Remove(technology);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TechnologyExists(int id)
        {
            return _context.Technology.Any(e => e.Id == id);
        }
    }
}
