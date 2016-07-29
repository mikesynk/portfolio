using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Data.Interfaces_Repositories;
using SGFlooring.Models;

namespace SGFlooring.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private const string FILEPATH = @"DataFiles\Product.txt";


        public Product GetProduct(Order order)
        {
            throw new NotImplementedException();
        }


        public List<Product> GetAllProducts()
        {

            List<Product> results = new List<Product>();

            var rows = File.ReadAllLines(FILEPATH);

            for (int i = 1; i < rows.Length; i++)
            {
                var columns = rows[i].Split(',');

                var product = new Product();
                product.ProductType = columns[0];
                product.MatlCostPerSqFt = decimal.Parse(columns[1]);
                product.LaborCostPerSqFt = decimal.Parse(columns[2]);


                results.Add(product);
            }

            return results;
        }
    }
}
