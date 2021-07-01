using ConsultaxMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultaxMVC.ViewModel
{
    public class AboutUsTable
    {
        public PagesContactUs PagesContactUs { get; set; }
        public List<AboutSlider> AboutSliders { get; set; }
        public List<AboutLogo> AboutLogos { get; set; }
        public List<AboutStatisticCount> AboutStatisticCounts { get; set; }
        public AboutWhatWeDo AboutWhatWeDo { get; set; }
    }
}
