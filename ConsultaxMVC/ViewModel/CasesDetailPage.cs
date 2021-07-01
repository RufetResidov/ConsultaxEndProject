using ConsultaxMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultaxMVC.ViewModel
{
    public class CasesDetailPage
    {
        public List<CustomerSayProject> CustomerSayProjects { get; set; }
        public ProsesWork ProsesWork{ get; set; }
        public DetailsProject DetailsProject { get; set; }
    }
}
