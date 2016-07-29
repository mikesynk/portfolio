using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGFlooring.Models
{
    public class Order
    {
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public DateTime Date { get; set; }
        public Product Product { get; set; }
        public State State { get; set; }
        public decimal Area { get; set; }

        public decimal MaterialCost => Area*Product.MatlCostPerSqFt;

        public decimal LaborCost => Area*Product.LaborCostPerSqFt;

        public decimal TaxCost => (((MaterialCost + LaborCost)*State.StateTaxRate)/100);

        public decimal TotalCost => MaterialCost + LaborCost + TaxCost;
    }
}
