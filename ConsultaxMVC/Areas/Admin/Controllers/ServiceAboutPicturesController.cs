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
    public class ServiceAboutPicturesController : Controller
    {
        private readonly ConsultaxTable _context;
        private readonly IWebHostEnvironment _environment;

        public ServiceAboutPicturesController(ConsultaxTable context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Admin/ServiceAboutPictures
        public async Task<IActionResult> Index()
        {
            return View(await _context.ServiceAboutPictures.ToListAsync());
        }

        // GET: Admin/ServiceAboutPictures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceAboutPicture = await _context.ServiceAboutPictures
                .FirstOrDefaultAsync(m => m.ID == id);
            if (serviceAboutPicture == null)
            {
                return NotFound();
            }

            return View(serviceAboutPicture);
        }

        // GET: Admin/ServiceAboutPictures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/ServiceAboutPictures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceAboutPicture serviceAboutPicture,IFormFile Photo)
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
                    serviceAboutPicture.Photo = "/img/" + FileName;
                }
                _context.Add(serviceAboutPicture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serviceAboutPicture);
        }

        // GET: Admin/ServiceAboutPictures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceAboutPicture = await _context.ServiceAboutPictures.FindAsync(id);
            if (serviceAboutPicture == null)
            {
                return NotFound();
            }
            return View(serviceAboutPicture);
        }

        // POST: Admin/ServiceAboutPictures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ServiceAboutPicture serviceAboutPicture, IFormFile Photo)
        {
            if (id != serviceAboutPicture.ID)
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
                        serviceAboutPicture.Photo = "/img/" + FileName;
                    }
                    _context.Update(serviceAboutPicture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceAboutPictureExists(serviceAboutPicture.ID))
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
            return View(serviceAboutPicture);
        }

        // GET: Admin/ServiceAboutPictures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceAboutPicture = await _context.ServiceAboutPictures
                .FirstOrDefaultAsync(m => m.ID == id);
            if (serviceAboutPicture == null)
            {
                return NotFound();
            }

            return View(serviceAboutPicture);
        }

        // POST: Admin/ServiceAboutPictures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var serviceAboutPicture = await _context.ServiceAboutPictures.FindAsync(id);
            _context.ServiceAboutPictures.Remove(serviceAboutPicture);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceAboutPictureExists(int id)
        {
            return _context.ServiceAboutPictures.Any(e => e.ID == id);
        }
    }
}
