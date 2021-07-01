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
    public class AboutWhatWeDoesController : Controller
    {
        private readonly ConsultaxTable _context;
        private readonly IWebHostEnvironment _environment;

        public AboutWhatWeDoesController(ConsultaxTable context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Admin/AboutWhatWeDoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.AboutWhatWeDos.ToListAsync());
        }

        // GET: Admin/AboutWhatWeDoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutWhatWeDo = await _context.AboutWhatWeDos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (aboutWhatWeDo == null)
            {
                return NotFound();
            }

            return View(aboutWhatWeDo);
        }

        // GET: Admin/AboutWhatWeDoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AboutWhatWeDoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile Photo, IFormFile Logo, AboutWhatWeDo aboutWhatWeDo)
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
                    aboutWhatWeDo.Photo = "/img/" + FileName;
                }
                if (Logo != null)
                {
                    var FileName = Guid.NewGuid() + Logo.FileName;
                    var wwwFolder = Path.Combine(_environment.WebRootPath, "img");
                    var imgFolder = Path.Combine(wwwFolder, FileName);
                    using var fileStream = new FileStream(imgFolder, FileMode.Create);
                    Logo.CopyTo(fileStream);
                    aboutWhatWeDo.Logo = "/img/" + FileName;
                }

                _context.Add(aboutWhatWeDo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aboutWhatWeDo);
        }

        // GET: Admin/AboutWhatWeDoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutWhatWeDo = await _context.AboutWhatWeDos.FindAsync(id);
            if (aboutWhatWeDo == null)
            {
                return NotFound();
            }
            return View(aboutWhatWeDo);
        }

        // POST: Admin/AboutWhatWeDoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormFile Photo, IFormFile Logo, AboutWhatWeDo aboutWhatWeDo)
        {
            if (id != aboutWhatWeDo.ID)
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
                        aboutWhatWeDo.Photo = "/img/" + FileName;
                    }
                    if (Logo != null)
                    {
                        var FileName = Guid.NewGuid() + Logo.FileName;
                        var wwwFolder = Path.Combine(_environment.WebRootPath, "img");
                        var imgFolder = Path.Combine(wwwFolder, FileName);
                        using var fileStream = new FileStream(imgFolder, FileMode.Create);
                        Logo.CopyTo(fileStream);
                        aboutWhatWeDo.Logo = "/img/" + FileName;
                    }
                    _context.Update(aboutWhatWeDo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AboutWhatWeDoExists(aboutWhatWeDo.ID))
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
            return View(aboutWhatWeDo);
        }

        // GET: Admin/AboutWhatWeDoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutWhatWeDo = await _context.AboutWhatWeDos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (aboutWhatWeDo == null)
            {
                return NotFound();
            }

            return View(aboutWhatWeDo);
        }

        // POST: Admin/AboutWhatWeDoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aboutWhatWeDo = await _context.AboutWhatWeDos.FindAsync(id);
            _context.AboutWhatWeDos.Remove(aboutWhatWeDo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AboutWhatWeDoExists(int id)
        {
            return _context.AboutWhatWeDos.Any(e => e.ID == id);
        }
    }
}
