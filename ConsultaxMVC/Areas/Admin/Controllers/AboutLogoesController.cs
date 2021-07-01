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
    public class AboutLogoesController : Controller
    {
        private readonly ConsultaxTable _context;
        private readonly IWebHostEnvironment _environment;

        public AboutLogoesController(ConsultaxTable context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Admin/AboutLogoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.AboutLogos.ToListAsync());
        }

        // GET: Admin/AboutLogoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutLogo = await _context.AboutLogos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (aboutLogo == null)
            {
                return NotFound();
            }

            return View(aboutLogo);
        }

        // GET: Admin/AboutLogoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AboutLogoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile Photo,AboutLogo aboutLogo)
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
                    aboutLogo.Photo = "/img/" + FileName;
                }
                _context.Add(aboutLogo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aboutLogo);
        }

        // GET: Admin/AboutLogoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutLogo = await _context.AboutLogos.FindAsync(id);
            if (aboutLogo == null)
            {
                return NotFound();
            }
            return View(aboutLogo);
        }

        // POST: Admin/AboutLogoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,IFormFile Photo,AboutLogo aboutLogo)
        {
            if (id != aboutLogo.ID)
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
                        aboutLogo.Photo = "/img/" + FileName;
                    }
                    _context.Update(aboutLogo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AboutLogoExists(aboutLogo.ID))
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
            return View(aboutLogo);
        }

        // GET: Admin/AboutLogoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutLogo = await _context.AboutLogos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (aboutLogo == null)
            {
                return NotFound();
            }

            return View(aboutLogo);
        }

        // POST: Admin/AboutLogoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aboutLogo = await _context.AboutLogos.FindAsync(id);
            _context.AboutLogos.Remove(aboutLogo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AboutLogoExists(int id)
        {
            return _context.AboutLogos.Any(e => e.ID == id);
        }
    }
}
