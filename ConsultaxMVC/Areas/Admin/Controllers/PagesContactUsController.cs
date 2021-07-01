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
    public class PagesContactUsController : Controller
    {
        private readonly ConsultaxTable _context;

        public PagesContactUsController(ConsultaxTable context)
        {
            _context = context;
        }

        // GET: Admin/PagesContactUs
        public async Task<IActionResult> Index()
        {
            return View(await _context.PagesContactUs.ToListAsync());
        }

        // GET: Admin/PagesContactUs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagesContactUs = await _context.PagesContactUs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pagesContactUs == null)
            {
                return NotFound();
            }

            return View(pagesContactUs);
        }

        // GET: Admin/PagesContactUs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/PagesContactUs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PhoneNumber,Adress")] PagesContactUs pagesContactUs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pagesContactUs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pagesContactUs);
        }

        // GET: Admin/PagesContactUs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagesContactUs = await _context.PagesContactUs.FindAsync(id);
            if (pagesContactUs == null)
            {
                return NotFound();
            }
            return View(pagesContactUs);
        }

        // POST: Admin/PagesContactUs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PhoneNumber,Adress")] PagesContactUs pagesContactUs)
        {
            if (id != pagesContactUs.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pagesContactUs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagesContactUsExists(pagesContactUs.ID))
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
            return View(pagesContactUs);
        }

        // GET: Admin/PagesContactUs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagesContactUs = await _context.PagesContactUs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pagesContactUs == null)
            {
                return NotFound();
            }

            return View(pagesContactUs);
        }

        // POST: Admin/PagesContactUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pagesContactUs = await _context.PagesContactUs.FindAsync(id);
            _context.PagesContactUs.Remove(pagesContactUs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagesContactUsExists(int id)
        {
            return _context.PagesContactUs.Any(e => e.ID == id);
        }
    }
}
