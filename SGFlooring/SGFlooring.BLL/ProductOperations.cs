using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Data.Factories;
using SGFlooring.Data.FakeRepositories;
using SGFlooring.Data.Repositories;
using SGFlooring.Models;

namespace SGFlooring.BLL
{
    public class ProductOperations
    {
        public Product GetProduct(string productType)
        {
            Product product = new Product() { ProductType = productType };
            var repo = ProductRepositoryFactory.GetProductRepository();


            List<Product> products = repo.GetAllProducts();

            foreach (Product p in products)
            {
                if (p.ProductType.ToUpper() == product.ProductType.ToUpper())
                {
                    product.MatlCostPerSqFt = p.MatlCostPerSqFt;
                    product.LaborCostPerSqFt = p.LaborCostPerSqFt;
                }
            }
            return product;
        }

    }
}
