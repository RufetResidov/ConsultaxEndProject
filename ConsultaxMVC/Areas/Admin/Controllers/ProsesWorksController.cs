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
    public class ProsesWorksController : Controller
    {
        private readonly ConsultaxTable _context;
        private readonly IWebHostEnvironment _environment;

        public ProsesWorksController(ConsultaxTable context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Admin/ProsesWorks
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProsesWorks.ToListAsync());
        }

        // GET: Admin/ProsesWorks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prosesWork = await _context.ProsesWorks
                .FirstOrDefaultAsync(m => m.ID == id);
            if (prosesWork == null)
            {
                return NotFound();
            }

            return View(prosesWork);
        }

        // GET: Admin/ProsesWorks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/ProsesWorks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile Photo,ProsesWork prosesWork)
        {
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    var fileName = Guid.NewGuid() + Photo.FileName;
                    var wwwFolder = Path.Combine(_environment.WebRootPath, "img");
                    var imgFolder = Path.Combine(wwwFolder, fileName);
                    using var fileStream = new FileStream(imgFolder, FileMode.Create);
                    Photo.CopyTo(fileStream);
                    prosesWork.Photo = "/img/" + fileName;
                };
                _context.Add(prosesWork);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prosesWork);
        }

        // GET: Admin/ProsesWorks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prosesWork = await _context.ProsesWorks.FindAsync(id);
            if (prosesWork == null)
            {
                return NotFound();
            }
            return View(prosesWork);
        }

        // POST: Admin/ProsesWorks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,IFormFile Photo, ProsesWork prosesWork)
        {
            if (id != prosesWork.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (Photo != null)
                    {
                        var fileName = Guid.NewGuid() + Photo.FileName;
                        var wwwFolder = Path.Combine(_environment.WebRootPath, "img");
                        var imgFolder = Path.Combine(wwwFolder, fileName);
                        using var fileStream = new FileStream(imgFolder, FileMode.Create);
                        Photo.CopyTo(fileStream);
                        prosesWork.Photo = "/img/" + fileName;
                    };
                    _context.Update(prosesWork);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProsesWorkExists(prosesWork.ID))
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
            return View(prosesWork);
        }

        // GET: Admin/ProsesWorks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prosesWork = await _context.ProsesWorks
                .FirstOrDefaultAsync(m => m.ID == id);
            if (prosesWork == null)
            {
                return NotFound();
            }

            return View(prosesWork);
        }

        // POST: Admin/ProsesWorks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prosesWork = await _context.ProsesWorks.FindAsync(id);
            _context.ProsesWorks.Remove(prosesWork);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProsesWorkExists(int id)
        {
            return _context.ProsesWorks.Any(e => e.ID == id);
        }
    }
}
