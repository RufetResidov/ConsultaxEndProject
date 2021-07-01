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
    public class DetailsProjectsController : Controller
    {
        private readonly ConsultaxTable _context;
        private readonly IWebHostEnvironment _environment;
        public DetailsProjectsController(ConsultaxTable context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Admin/DetailsProjects
        public async Task<IActionResult> Index()
        {
            return View(await _context.DetailsProjects.ToListAsync());
        }

        // GET: Admin/DetailsProjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detailsProject = await _context.DetailsProjects
                .FirstOrDefaultAsync(m => m.ID == id);
            if (detailsProject == null)
            {
                return NotFound();
            }

            return View(detailsProject);
        }

        // GET: Admin/DetailsProjects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/DetailsProjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile Logo, DetailsProject detailsProject)
        {
            if (ModelState.IsValid)
            {
                if (Logo != null)
                {
                    var fileName = Guid.NewGuid() + Logo.FileName;
                    var wwwFolder = Path.Combine(_environment.WebRootPath, "img");
                    var imgFolder = Path.Combine(wwwFolder, fileName);
                    using var fileStream = new FileStream(imgFolder, FileMode.Create);
                    Logo.CopyTo(fileStream);
                    detailsProject.Logo = "/img/" + fileName;
                };
                _context.Add(detailsProject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(detailsProject);
        }

        // GET: Admin/DetailsProjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detailsProject = await _context.DetailsProjects.FindAsync(id);
            if (detailsProject == null)
            {
                return NotFound();
            }
            return View(detailsProject);
        }

        // POST: Admin/DetailsProjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,IFormFile Logo,DetailsProject detailsProject)
        {
            if (id != detailsProject.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (Logo != null)
                    {
                        var fileName = Guid.NewGuid() + Logo.FileName;
                        var wwwFolder = Path.Combine(_environment.WebRootPath, "img");
                        var imgFolder = Path.Combine(wwwFolder, fileName);
                        using var fileStream = new FileStream(imgFolder, FileMode.Create);
                        Logo.CopyTo(fileStream);
                        detailsProject.Logo = "/img/" + fileName;
                    };
                    _context.Update(detailsProject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetailsProjectExists(detailsProject.ID))
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
            return View(detailsProject);
        }

        // GET: Admin/DetailsProjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detailsProject = await _context.DetailsProjects
                .FirstOrDefaultAsync(m => m.ID == id);
            if (detailsProject == null)
            {
                return NotFound();
            }

            return View(detailsProject);
        }

        // POST: Admin/DetailsProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detailsProject = await _context.DetailsProjects.FindAsync(id);
            _context.DetailsProjects.Remove(detailsProject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetailsProjectExists(int id)
        {
            return _context.DetailsProjects.Any(e => e.ID == id);
        }
    }
}
