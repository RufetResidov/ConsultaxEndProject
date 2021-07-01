using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConsultaxMVC.Data;
using ConsultaxMVC.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace ConsultaxMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeaturedProjectsController : Controller
    {
        private readonly ConsultaxTable _context;
        private readonly IWebHostEnvironment _environment;
        public FeaturedProjectsController(ConsultaxTable context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Admin/FeaturedProjects
        public async Task<IActionResult> Index()
        {
            return View(await _context.FeaturedProjects.ToListAsync());
        }

        // GET: Admin/FeaturedProjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var featuredProject = await _context.FeaturedProjects
                .FirstOrDefaultAsync(m => m.ID == id);
            if (featuredProject == null)
            {
                return NotFound();
            }

            return View(featuredProject);
        }

        // GET: Admin/FeaturedProjects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/FeaturedProjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FeaturedProject featuredProject,IFormFile Photo)
        {
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    var FileName = Guid.NewGuid() + Photo.FileName;
                    var wwwFolder = Path.Combine(_environment.WebRootPath, "img");
                    var imgFolder = Path.Combine(wwwFolder, FileName);
                    using var fileStream = new FileStream(imgFolder, FileMode.Create);
                    Photo.CopyTo(fileStream);
                    featuredProject.Photo = "/img/" + FileName;
                }
                _context.Add(featuredProject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(featuredProject);
        }

        // GET: Admin/FeaturedProjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var featuredProject = await _context.FeaturedProjects.FindAsync(id);
            if (featuredProject == null)
            {
                return NotFound();
            }
            return View(featuredProject);
        }

        // POST: Admin/FeaturedProjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FeaturedProject featuredProject,IFormFile Photo)
        {
            if (id != featuredProject.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (Photo != null)
                    {
                        var FileName = Guid.NewGuid() + Photo.FileName;
                        var wwwFolder = Path.Combine(_environment.WebRootPath, "img");
                        var imgFolder = Path.Combine(wwwFolder, FileName);
                        using var fileStream = new FileStream(imgFolder, FileMode.Create);
                        Photo.CopyTo(fileStream);
                        featuredProject.Photo = "/img/" + FileName;
                    }
                    _context.Update(featuredProject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeaturedProjectExists(featuredProject.ID))
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
            return View(featuredProject);
        }

        // GET: Admin/FeaturedProjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var featuredProject = await _context.FeaturedProjects
                .FirstOrDefaultAsync(m => m.ID == id);
            if (featuredProject == null)
            {
                return NotFound();
            }

            return View(featuredProject);
        }

        // POST: Admin/FeaturedProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var featuredProject = await _context.FeaturedProjects.FindAsync(id);
            _context.FeaturedProjects.Remove(featuredProject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeaturedProjectExists(int id)
        {
            return _context.FeaturedProjects.Any(e => e.ID == id);
        }
    }
}
