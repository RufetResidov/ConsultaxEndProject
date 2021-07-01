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
    public class CustomerSayProjectsController : Controller
    {
        private readonly ConsultaxTable _context;
        private readonly IWebHostEnvironment _environment;
        public CustomerSayProjectsController(ConsultaxTable context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Admin/CustomerSayProjects
        public async Task<IActionResult> Index()
        {
            return View(await _context.CustomerSayProjects.ToListAsync());
        }

        // GET: Admin/CustomerSayProjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerSayProject = await _context.CustomerSayProjects
                .FirstOrDefaultAsync(m => m.ID == id);
            if (customerSayProject == null)
            {
                return NotFound();
            }

            return View(customerSayProject);
        }

        // GET: Admin/CustomerSayProjects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/CustomerSayProjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile Photo, CustomerSayProject customerSayProject)
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
                    customerSayProject.Photo = "/img/" + fileName;
                };
                _context.Add(customerSayProject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerSayProject);
        }

        // GET: Admin/CustomerSayProjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerSayProject = await _context.CustomerSayProjects.FindAsync(id);
            if (customerSayProject == null)
            {
                return NotFound();
            }
            return View(customerSayProject);
        }

        // POST: Admin/CustomerSayProjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,IFormFile Photo,CustomerSayProject customerSayProject)
        {
            if (id != customerSayProject.ID)
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
                        customerSayProject.Photo = "/img/" + fileName;
                    };
                    _context.Update(customerSayProject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerSayProjectExists(customerSayProject.ID))
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
            return View(customerSayProject);
        }

        // GET: Admin/CustomerSayProjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerSayProject = await _context.CustomerSayProjects
                .FirstOrDefaultAsync(m => m.ID == id);
            if (customerSayProject == null)
            {
                return NotFound();
            }

            return View(customerSayProject);
        }

        // POST: Admin/CustomerSayProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customerSayProject = await _context.CustomerSayProjects.FindAsync(id);
            _context.CustomerSayProjects.Remove(customerSayProject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerSayProjectExists(int id)
        {
            return _context.CustomerSayProjects.Any(e => e.ID == id);
        }
    }
}
