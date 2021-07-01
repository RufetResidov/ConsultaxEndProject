using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConsultaxMVC.Data;
using ConsultaxMVC.Models;

namespace ConsultaxMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CareerHiringsController : Controller
    {
        private readonly ConsultaxTable _context;

        public CareerHiringsController(ConsultaxTable context)
        {
            _context = context;
        }

        // GET: Admin/CareerHirings
        public async Task<IActionResult> Index()
        {
            return View(await _context.CareerHirings.ToListAsync());
        }

        // GET: Admin/CareerHirings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var careerHiring = await _context.CareerHirings
                .FirstOrDefaultAsync(m => m.ID == id);
            if (careerHiring == null)
            {
                return NotFound();
            }

            return View(careerHiring);
        }

        // GET: Admin/CareerHirings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/CareerHirings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PersonText,Description,DescriptionTitle,DesiredSkill,DesiredTitle")] CareerHiring careerHiring)
        {
            if (ModelState.IsValid)
            {
                _context.Add(careerHiring);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(careerHiring);
        }

        // GET: Admin/CareerHirings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var careerHiring = await _context.CareerHirings.FindAsync(id);
            if (careerHiring == null)
            {
                return NotFound();
            }
            return View(careerHiring);
        }

        // POST: Admin/CareerHirings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PersonText,Description,DescriptionTitle,DesiredSkill,DesiredTitle")] CareerHiring careerHiring)
        {
            if (id != careerHiring.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(careerHiring);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CareerHiringExists(careerHiring.ID))
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
            return View(careerHiring);
        }

        // GET: Admin/CareerHirings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var careerHiring = await _context.CareerHirings
                .FirstOrDefaultAsync(m => m.ID == id);
            if (careerHiring == null)
            {
                return NotFound();
            }

            return View(careerHiring);
        }

        // POST: Admin/CareerHirings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var careerHiring = await _context.CareerHirings.FindAsync(id);
            _context.CareerHirings.Remove(careerHiring);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CareerHiringExists(int id)
        {
            return _context.CareerHirings.Any(e => e.ID == id);
        }
    }
}
