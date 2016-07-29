using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Models;

namespace SGFlooring.Data.Interfaces_Repositories
{
    public interface IProductRepository
    {
        Product GetProduct(Order order);
        List<Product> GetAllProducts();
    }
}
