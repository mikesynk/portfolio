using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGFlooring.Models
{
    public class Product
    {
        public string ProductType { get; set; }
        public decimal MatlCostPerSqFt { get; set; }
        public decimal LaborCostPerSqFt { get; set; }
    }
}
