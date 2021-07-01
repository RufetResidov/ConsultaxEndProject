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
    public class AboutStatisticCountsController : Controller
    {
        private readonly ConsultaxTable _context;

        public AboutStatisticCountsController(ConsultaxTable context)
        {
            _context = context;
        }

        // GET: Admin/AboutStatisticCounts
        public async Task<IActionResult> Index()
        {
            return View(await _context.AboutStatisticCounts.ToListAsync());
        }

        // GET: Admin/AboutStatisticCounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutStatisticCount = await _context.AboutStatisticCounts
                .FirstOrDefaultAsync(m => m.ID == id);
            if (aboutStatisticCount == null)
            {
                return NotFound();
            }

            return View(aboutStatisticCount);
        }

        // GET: Admin/AboutStatisticCounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AboutStatisticCounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,countNum,TitleLeft,TitleRight")] AboutStatisticCount aboutStatisticCount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aboutStatisticCount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aboutStatisticCount);
        }

        // GET: Admin/AboutStatisticCounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutStatisticCount = await _context.AboutStatisticCounts.FindAsync(id);
            if (aboutStatisticCount == null)
            {
                return NotFound();
            }
            return View(aboutStatisticCount);
        }

        // POST: Admin/AboutStatisticCounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,countNum,TitleLeft,TitleRight")] AboutStatisticCount aboutStatisticCount)
        {
            if (id != aboutStatisticCount.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aboutStatisticCount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AboutStatisticCountExists(aboutStatisticCount.ID))
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
            return View(aboutStatisticCount);
        }

        // GET: Admin/AboutStatisticCounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutStatisticCount = await _context.AboutStatisticCounts
                .FirstOrDefaultAsync(m => m.ID == id);
            if (aboutStatisticCount == null)
            {
                return NotFound();
            }

            return View(aboutStatisticCount);
        }

        // POST: Admin/AboutStatisticCounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aboutStatisticCount = await _context.AboutStatisticCounts.FindAsync(id);
            _context.AboutStatisticCounts.Remove(aboutStatisticCount);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AboutStatisticCountExists(int id)
        {
            return _context.AboutStatisticCounts.Any(e => e.ID == id);
        }
    }
}
