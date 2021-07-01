using ConsultaxMVC.Data;
using ConsultaxMVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultaxMVC.Controllers
{
    public class CasesController : Controller
    {
        private readonly ConsultaxTable _context;

        public CasesController(ConsultaxTable context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HomeVm vm = new()
            {
                
                FeaturedProjects=_context.FeaturedProjects.ToList(),
                PictureProjects=_context.PictureProjects.ToList(),
            };
           

            return View(vm);
        }
        public IActionResult Detail()
        {
            CasesDetailPage cs = new()
            {
                CustomerSayProjects = _context.CustomerSayProjects.ToList(),
                DetailsProject = _context.DetailsProjects.FirstOrDefault(),
                ProsesWork = _context.ProsesWorks.FirstOrDefault(),
            };
            return View(cs);
        }
    }
}
