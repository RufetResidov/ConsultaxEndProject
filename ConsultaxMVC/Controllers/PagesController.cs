using ConsultaxMVC.Data;
using ConsultaxMVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultaxMVC.Controllers
{
    public class PagesController : Controller
    {
        private readonly ConsultaxTable _context;

        public PagesController(ConsultaxTable context)
        {
            _context = context;
        }

        public IActionResult AboutUs()
        {
            AboutUsTable aus = new()
            {
                PagesContactUs = _context.PagesContactUs.FirstOrDefault(),
                AboutSliders = _context.AboutSliders.ToList(),
                AboutLogos = _context.AboutLogos.ToList(),
                AboutStatisticCounts = _context.AboutStatisticCounts.ToList(),
                AboutWhatWeDo = _context.AboutWhatWeDos.FirstOrDefault(),
            };
            return View(aus);
        }
        public IActionResult IconBox()
        {
            return View(_context.AllServices.ToList());
        }
        public IActionResult OurTeam()
        {
            OurTeamPages otp = new()
            {
                TeamExperts = _context.TeamExperts.ToList(),
                TeamLeaderShips = _context.TeamLeaderShips.ToList()
            };
            return View(otp);
        }
        public IActionResult Career()
        {
            CareerPages cp = new()
            {
                PagesContactUs=_context.PagesContactUs.FirstOrDefault(),
                CareerHirings=_context.CareerHirings.ToList()
            };
            return View(cp);
        }
        public IActionResult ServiceBox()
        {
            ServiceAboutPic sb = new()
            {
                ServiceAboutPictures = _context.ServiceAboutPictures.ToList(),
            };
            return View(sb);
        }
    }
}
