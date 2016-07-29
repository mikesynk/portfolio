using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Models;

namespace SGFlooring.Data.Interfaces_Repositories
{
    public interface IOrderRepository
    {
        Order AddOrder(DateTime date, Order order);
        Order EditOrder(DateTime date, Order order);
        Order DisplayOrder(int orderNumber, DateTime date);
        List<Order> GetAllOrders(DateTime date);
        Order RemoveOrder(DateTime date, Order order);
    }
}
