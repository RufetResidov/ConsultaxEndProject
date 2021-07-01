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
    public class SectionOnesController : Controller
    {
        private readonly ConsultaxTable _context;
        private IWebHostEnvironment _environment;
        public SectionOnesController(ConsultaxTable context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Admin/SectionOnes
        public async Task<IActionResult> Index()
        {
            return View(await _context.SectionOnes.ToListAsync());
        }

        // GET: Admin/SectionOnes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sectionOne = await _context.SectionOnes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sectionOne == null)
            {
                return NotFound();
            }

            return View(sectionOne);
        }

        // GET: Admin/SectionOnes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/SectionOnes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( SectionOne sectionOne,IFormFile PhotoUrl )
        {
            if (ModelState.IsValid)
            {
                if (PhotoUrl != null)
                {
                    var FileName = Guid.NewGuid() + PhotoUrl.FileName;
                    var wwwFolder = Path.Combine(_environment.WebRootPath, "img");
                    var imgFolder = Path.Combine(wwwFolder, FileName);
                    using var fileStream = new FileStream(imgFolder, FileMode.Create);
                    PhotoUrl.CopyTo(fileStream);
                    sectionOne.PhotoUrl = "/img/" + FileName;
                }
                _context.Add(sectionOne);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sectionOne);
        }

        // GET: Admin/SectionOnes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sectionOne = await _context.SectionOnes.FindAsync(id);
            if (sectionOne == null)
            {
                return NotFound();
            }
            return View(sectionOne);
        }

        // POST: Admin/SectionOnes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,SectionOne sectionOne,IFormFile PhotoUrl)
        {
            if (id != sectionOne.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (PhotoUrl != null)
                    {
                        var FileName = Guid.NewGuid() + PhotoUrl.FileName;
                        var wwwFolder = Path.Combine(_environment.WebRootPath, "img");
                        var imgFolder = Path.Combine(wwwFolder, FileName);
                        using var fileStream = new FileStream(imgFolder, FileMode.Create);
                        PhotoUrl.CopyTo(fileStream);
                        sectionOne.PhotoUrl = "/img/" + FileName;
                    }
                    _context.Update(sectionOne);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SectionOneExists(sectionOne.ID))
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
            return View(sectionOne);
        }

        // GET: Admin/SectionOnes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sectionOne = await _context.SectionOnes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sectionOne == null)
            {
                return NotFound();
            }

            return View(sectionOne);
        }

        // POST: Admin/SectionOnes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sectionOne = await _context.SectionOnes.FindAsync(id);
            _context.SectionOnes.Remove(sectionOne);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SectionOneExists(int id)
        {
            return _context.SectionOnes.Any(e => e.ID == id);
        }
    }
}
