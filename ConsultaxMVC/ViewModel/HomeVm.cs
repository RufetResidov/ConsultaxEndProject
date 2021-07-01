using ConsultaxMVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultaxMVC.ViewModel
{
    public class HomeVm
    {
        public List<FeaturedProject> FeaturedProjects { get; set; }
        public List<PictureProject> PictureProjects { get; set; }
       
    }
}
