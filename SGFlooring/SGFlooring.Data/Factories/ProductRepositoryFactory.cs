using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Data.FakeRepositories;
using SGFlooring.Data.Interfaces_Repositories;
using SGFlooring.Data.Repositories;

namespace SGFlooring.Data.Factories
{
    public static class ProductRepositoryFactory
    {
        public static IProductRepository GetProductRepository()
        {
            var mode = ConfigurationManager.AppSettings["Mode"];

            switch (mode)
            {
                case "Test":
                    return new FakeProductRepository();
                default:
                    return new ProductRepository();
            }
        }
    }
}
