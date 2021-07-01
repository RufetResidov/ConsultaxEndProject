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
    public class PictureProjectsController : Controller
    {
        private readonly ConsultaxTable _context;
        private readonly IWebHostEnvironment _environment;

        public PictureProjectsController(ConsultaxTable context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Admin/PictureProjects
        public async Task<IActionResult> Index()
        {
            return View(await _context.PictureProjects.ToListAsync());
        }

        // GET: Admin/PictureProjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pictureProject = await _context.PictureProjects
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pictureProject == null)
            {
                return NotFound();
            }

            return View(pictureProject);
        }

        // GET: Admin/PictureProjects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/PictureProjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile Photo, PictureProject pictureProject)
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
                    pictureProject.Photo = "/img/" + FileName;
                }
                _context.Add(pictureProject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pictureProject);
        }

        // GET: Admin/PictureProjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pictureProject = await _context.PictureProjects.FindAsync(id);
            if (pictureProject == null)
            {
                return NotFound();
            }
            return View(pictureProject);
        }

        // POST: Admin/PictureProjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PictureProject pictureProject,IFormFile Photo)
        {
            if (id != pictureProject.ID)
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
                        pictureProject.Photo = "/img/" + FileName;
                    }
                    _context.Update(pictureProject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PictureProjectExists(pictureProject.ID))
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
            return View(pictureProject);
        }

        // GET: Admin/PictureProjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pictureProject = await _context.PictureProjects
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pictureProject == null)
            {
                return NotFound();
            }

            return View(pictureProject);
        }

        // POST: Admin/PictureProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pictureProject = await _context.PictureProjects.FindAsync(id);
            _context.PictureProjects.Remove(pictureProject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PictureProjectExists(int id)
        {
            return _context.PictureProjects.Any(e => e.ID == id);
        }
    }
}
