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
    public class AboutSlidersController : Controller
    {
        private readonly ConsultaxTable _context;
        private readonly IWebHostEnvironment _environment;

        public AboutSlidersController(ConsultaxTable context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Admin/AboutSliders
        public async Task<IActionResult> Index()
        {
            return View(await _context.AboutSliders.ToListAsync());
        }

        // GET: Admin/AboutSliders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutSlider = await _context.AboutSliders
                .FirstOrDefaultAsync(m => m.ID == id);
            if (aboutSlider == null)
            {
                return NotFound();
            }

            return View(aboutSlider);
        }

        // GET: Admin/AboutSliders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AboutSliders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile Photo, AboutSlider aboutSlider)
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
                    aboutSlider.Photo = "/img/" + FileName;
                }
                _context.Add(aboutSlider);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aboutSlider);
        }

        // GET: Admin/AboutSliders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutSlider = await _context.AboutSliders.FindAsync(id);
            if (aboutSlider == null)
            {
                return NotFound();
            }
            return View(aboutSlider);
        }

        // POST: Admin/AboutSliders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,IFormFile Photo,AboutSlider aboutSlider)
        {
            if (id != aboutSlider.ID)
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
                        aboutSlider.Photo = "/img/" + FileName;
                    }
                    _context.Update(aboutSlider);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AboutSliderExists(aboutSlider.ID))
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
            return View(aboutSlider);
        }

        // GET: Admin/AboutSliders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutSlider = await _context.AboutSliders
                .FirstOrDefaultAsync(m => m.ID == id);
            if (aboutSlider == null)
            {
                return NotFound();
            }

            return View(aboutSlider);
        }

        // POST: Admin/AboutSliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aboutSlider = await _context.AboutSliders.FindAsync(id);
            _context.AboutSliders.Remove(aboutSlider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AboutSliderExists(int id)
        {
            return _context.AboutSliders.Any(e => e.ID == id);
        }
    }
}
