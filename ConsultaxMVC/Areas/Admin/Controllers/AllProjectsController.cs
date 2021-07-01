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
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace ConsultaxMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AllProjectsController : Controller
    {
        private readonly ConsultaxTable _context;
        private IWebHostEnvironment _environment;

        public AllProjectsController(ConsultaxTable context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Admin/AllProjects
        public async Task<IActionResult> Index()
        {
            return View(await _context.AllProjects.ToListAsync());
        }

        // GET: Admin/AllProjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allProject = await _context.AllProjects
                .FirstOrDefaultAsync(m => m.ID == id);
            if (allProject == null)
            {
                return NotFound();
            }

            return View(allProject);
        }

        // GET: Admin/AllProjects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AllProjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AllProject allProject,IFormFile PhotoUrl,IFormFile Logo)
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
                    allProject.PhotoUrl = "/img/" + fileName;
                }
                if (Logo != null)
                {
                    var fileName = Guid.NewGuid() + Logo.FileName;
                    var wwwFolder = Path.Combine(_environment.WebRootPath, "img");
                    var imgFolder = Path.Combine(wwwFolder, fileName);
                    using var fileStram = new FileStream(imgFolder, FileMode.Create);
                    Logo.CopyTo(fileStram);
                    allProject.Logo = "/img/" + fileName;
                }
                _context.Add(allProject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(allProject);
        }

        // GET: Admin/AllProjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allProject = await _context.AllProjects.FindAsync(id);
            if (allProject == null)
            {
                return NotFound();
            }
            return View(allProject);
        }

        // POST: Admin/AllProjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AllProject allProject,IFormFile PhotoUrl,IFormFile Logo)
        {
            if (id != allProject.ID)
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
                        allProject.PhotoUrl = "/img/" + fileName;
                    }
                    if (Logo != null)
                    {
                        var fileName = Guid.NewGuid() + Logo.FileName;
                        var wwwFolder = Path.Combine(_environment.WebRootPath, "img");
                        var imgFolder = Path.Combine(wwwFolder, fileName);
                        using var fileStram = new FileStream(imgFolder, FileMode.Create);
                        Logo.CopyTo(fileStram);
                        allProject.Logo = "/img/" + fileName;
                    }
                    _context.Update(allProject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AllProjectExists(allProject.ID))
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
            return View(allProject);
        }

        // GET: Admin/AllProjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allProject = await _context.AllProjects
                .FirstOrDefaultAsync(m => m.ID == id);
            if (allProject == null)
            {
                return NotFound();
            }

            return View(allProject);
        }

        // POST: Admin/AllProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var allProject = await _context.AllProjects.FindAsync(id);
            _context.AllProjects.Remove(allProject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AllProjectExists(int id)
        {
            return _context.AllProjects.Any(e => e.ID == id);
        }
    }
}
