using ConsultaxMVC.Data;
using ConsultaxMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultaxMVC.Controllers
{
    public class BlogController : Controller
    {
        private readonly ConsultaxTable _context;

        public BlogController(ConsultaxTable context)
        {
            _context = context;
        }

        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Blog selectedBlog = _context.Blogs.FirstOrDefault(x => x.ID == id);

            if (selectedBlog == null)
            {
                return NotFound();
            }
            ViewData["blogDetail"] = selectedBlog;
            ViewData["blogs"] = _context.Blogs.Where(x=>x.ID!=id).OrderByDescending(x => x.PublishDate).Take(5).ToList();
            return View(selectedBlog);
        }
        public IActionResult Index()
        {
            ViewData["blogs"] = _context.Blogs.OrderByDescending(x => x.PublishDate).Take(5).ToList(); 
            return View();
        }
    }
}
