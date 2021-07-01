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
    public class TeamLeaderShipsController : Controller
    {
        private readonly ConsultaxTable _context;
        private readonly IWebHostEnvironment _environment;
        public TeamLeaderShipsController(ConsultaxTable context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Admin/TeamLeaderShips1
        public async Task<IActionResult> Index()
        {
            return View(await _context.TeamLeaderShips.ToListAsync());
        }

        // GET: Admin/TeamLeaderShips1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamLeaderShip = await _context.TeamLeaderShips
                .FirstOrDefaultAsync(m => m.ID == id);
            if (teamLeaderShip == null)
            {
                return NotFound();
            }

            return View(teamLeaderShip);
        }

        // GET: Admin/TeamLeaderShips1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/TeamLeaderShips1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeamLeaderShip teamLeaderShip, IFormFile Photo)
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
                    teamLeaderShip.Photo = "/img/" + FileName;
                }
                _context.Add(teamLeaderShip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teamLeaderShip);
        }

        // GET: Admin/TeamLeaderShips1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamLeaderShip = await _context.TeamLeaderShips.FindAsync(id);
            if (teamLeaderShip == null)
            {
                return NotFound();
            }
            return View(teamLeaderShip);
        }

        // POST: Admin/TeamLeaderShips1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,IFormFile Photo,TeamLeaderShip teamLeaderShip)
        {
            if (id != teamLeaderShip.ID)
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
                        teamLeaderShip.Photo = "/img/" + FileName;
                    }
                    _context.Update(teamLeaderShip);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamLeaderShipExists(teamLeaderShip.ID))
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
            return View(teamLeaderShip);
        }

        // GET: Admin/TeamLeaderShips1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamLeaderShip = await _context.TeamLeaderShips
                .FirstOrDefaultAsync(m => m.ID == id);
            if (teamLeaderShip == null)
            {
                return NotFound();
            }

            return View(teamLeaderShip);
        }

        // POST: Admin/TeamLeaderShips1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teamLeaderShip = await _context.TeamLeaderShips.FindAsync(id);
            _context.TeamLeaderShips.Remove(teamLeaderShip);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeamLeaderShipExists(int id)
        {
            return _context.TeamLeaderShips.Any(e => e.ID == id);
        }
    }
}
