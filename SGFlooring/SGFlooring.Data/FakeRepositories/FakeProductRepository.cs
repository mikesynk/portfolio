using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Data.Interfaces_Repositories;
using SGFlooring.Models;

namespace SGFlooring.Data.FakeRepositories
{
    public class FakeProductRepository : IProductRepository
    {
        private static List<Product> products;

        public FakeProductRepository()
        {
            products = new List<Product>();

            if (products.Count == 0)
            {
                products = new List<Product>()
                {
                    new Product() {ProductType = "wood", MatlCostPerSqFt = 4.00m, LaborCostPerSqFt = 3.00m},
                    new Product() {ProductType = "carpet", MatlCostPerSqFt = 1.75m, LaborCostPerSqFt = 2.75m},
                    new Product() {ProductType = "laminate", MatlCostPerSqFt = 2.75m, LaborCostPerSqFt = 2.50m}
                };
            }
        }

        public Product GetProduct(Order order)
        {
            return products.FirstOrDefault(p => p.ProductType.ToString() == order.Product.ToString());
        }

        public List<Product> GetAllProducts()
        {
            return products;
        }
    }
}
