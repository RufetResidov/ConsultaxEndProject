using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConsultaxMVC.Data;
using ConsultaxMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace ConsultaxMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WhoWeAresController : Controller
    {
        private readonly ConsultaxTable _context;
        private IWebHostEnvironment _environment;
        public WhoWeAresController(ConsultaxTable context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Admin/WhoWeAres
        public async Task<IActionResult> Index()
        {
            return View(await _context.WhoWeAres.ToListAsync());
        }

        // GET: Admin/WhoWeAres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var whoWeAre = await _context.WhoWeAres
                .FirstOrDefaultAsync(m => m.ID == id);
            if (whoWeAre == null)
            {
                return NotFound();
            }

            return View(whoWeAre);
        }

        // GET: Admin/WhoWeAres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/WhoWeAres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( WhoWeAre whoWeAre,IFormFile PhotoUrl,IFormFile SignaturePhoto)
        {
            if (ModelState.IsValid)
            {
                if (PhotoUrl != null)
                {
                    var fileName = Guid.NewGuid() + PhotoUrl.FileName;
                    var wwwFolder = Path.Combine(_environment.WebRootPath, "img");
                    var imgFolder = Path.Combine(wwwFolder, fileName);
                    using var fileStram = new FileStream(imgFolder, FileMode.Create);
                    PhotoUrl.CopyTo(fileStram);
                    whoWeAre.PhotoUrl = "/img/" + fileName;
                }
                if (SignaturePhoto != null)
                {
                    var fileName = Guid.NewGuid() + SignaturePhoto.FileName;
                    var wwwFolder = Path.Combine(_environment.WebRootPath, "img");
                    var imgFolder = Path.Combine(wwwFolder, fileName);
                    using var fileStram = new FileStream(imgFolder, FileMode.Create);
                    PhotoUrl.CopyTo(fileStram);
                    whoWeAre.SignaturePhoto = "/img/" + fileName;
                }
                _context.Add(whoWeAre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(whoWeAre);
        }

        // GET: Admin/WhoWeAres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var whoWeAre = await _context.WhoWeAres.FindAsync(id);
            if (whoWeAre == null)
            {
                return NotFound();
            }
            return View(whoWeAre);
        }

        // POST: Admin/WhoWeAres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, WhoWeAre whoWeAre,IFormFile PhotoUrl,IFormFile SignaturePhoto)
        {
            if (id != whoWeAre.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (PhotoUrl != null)
                    {
                        var fileName = Guid.NewGuid() + PhotoUrl.FileName;
                        var wwwFolder = Path.Combine(_environment.WebRootPath, "img");
                        var imgFolder = Path.Combine(wwwFolder, fileName);
                        using var fileStram = new FileStream(imgFolder, FileMode.Create);
                        PhotoUrl.CopyTo(fileStram);
                        whoWeAre.PhotoUrl = "/img/" + fileName;
                    }
                    if (SignaturePhoto != null)
                    {
                        var fileName = Guid.NewGuid() + SignaturePhoto.FileName;
                        var wwwFolder = Path.Combine(_environment.WebRootPath, "img");
                        var imgFolder = Path.Combine(wwwFolder, fileName);
                        using var fileStram = new FileStream(imgFolder, FileMode.Create);
                        SignaturePhoto.CopyTo(fileStram);
                        whoWeAre.SignaturePhoto = "/img/" + fileName;
                    }
                    _context.Update(whoWeAre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WhoWeAreExists(whoWeAre.ID))
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
            return View(whoWeAre);
        }

        // GET: Admin/WhoWeAres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var whoWeAre = await _context.WhoWeAres
                .FirstOrDefaultAsync(m => m.ID == id);
            if (whoWeAre == null)
            {
                return NotFound();
            }

            return View(whoWeAre);
        }

        // POST: Admin/WhoWeAres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var whoWeAre = await _context.WhoWeAres.FindAsync(id);
            _context.WhoWeAres.Remove(whoWeAre);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WhoWeAreExists(int id)
        {
            return _context.WhoWeAres.Any(e => e.ID == id);
        }
    }
}
