using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultaxMVC.Models
{
    public class FeaturedProject
    {
        public int ID { get; set; }
        public string Photo { get; set; }
        public DateTime ContractDate { get; set; }
        public string WorkArea { get; set; }

    }
}
