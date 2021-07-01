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
    public class TeamExpertsController : Controller
    {
        private readonly ConsultaxTable _context;
        private readonly IWebHostEnvironment _environment;

        public TeamExpertsController(ConsultaxTable context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Admin/TeamExperts1
        public async Task<IActionResult> Index()
        {
            return View(await _context.TeamExperts.ToListAsync());
        }

        // GET: Admin/TeamExperts1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamExpert = await _context.TeamExperts
                .FirstOrDefaultAsync(m => m.ID == id);
            if (teamExpert == null)
            {
                return NotFound();
            }

            return View(teamExpert);
        }

        // GET: Admin/TeamExperts1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/TeamExperts1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( TeamExpert teamExpert,IFormFile Photo)
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
                    teamExpert.Photo = "/img/" + FileName;
                }
                _context.Add(teamExpert);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teamExpert);
        }

        // GET: Admin/TeamExperts1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamExpert = await _context.TeamExperts.FindAsync(id);
            if (teamExpert == null)
            {
                return NotFound();
            }
            return View(teamExpert);
        }

        // POST: Admin/TeamExperts1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TeamExpert teamExpert,IFormFile Photo)
        {
            if (id != teamExpert.ID)
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
                        teamExpert.Photo = "/img/" + FileName;
                    }
                    _context.Update(teamExpert);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamExpertExists(teamExpert.ID))
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
            return View(teamExpert);
        }

        // GET: Admin/TeamExperts1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamExpert = await _context.TeamExperts
                .FirstOrDefaultAsync(m => m.ID == id);
            if (teamExpert == null)
            {
                return NotFound();
            }

            return View(teamExpert);
        }

        // POST: Admin/TeamExperts1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teamExpert = await _context.TeamExperts.FindAsync(id);
            _context.TeamExperts.Remove(teamExpert);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeamExpertExists(int id)
        {
            return _context.TeamExperts.Any(e => e.ID == id);
        }
    }
}
