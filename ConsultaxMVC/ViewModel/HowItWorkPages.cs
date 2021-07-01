using ConsultaxMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultaxMVC.ViewModel
{
    public class HowItWorkPages
    {
        public List<WorkClient> WorkClients { get; set; }
        public WorkBackground WorkBackground { get; set; }
        public List<WorkFeatured> WorkFeatureds { get; set; }
    }
}
