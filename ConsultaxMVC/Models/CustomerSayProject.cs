using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultaxMVC.Models
{
    public class CustomerSayProject
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Photo { get; set; }
        public string Name { get; set; }
        public string WorkName { get; set; }
        public decimal? Rating { get; set; }
    }
}
