using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Data.Interfaces_Repositories;
using SGFlooring.Models;

namespace SGFlooring.Data.FakeRepositories
{
    public class FakeOrderRepository : IOrderRepository
    {
        //public static List<Order> orders;
        private static Dictionary<DateTime, List<Order>> _orders;

        public FakeOrderRepository()
        {
            if (_orders == null)
            {
                _orders = new Dictionary<DateTime, List<Order>>();

                Order order = new Order();

                _orders.Add(new DateTime(2016,05,29), new List<Order>()
                //_orders.Add(new DateTime(), new List<Order>()
                {
                    new Order() {OrderNumber = 1, CustomerName = "Ben Superior", Date = new DateTime(2016,05,29),
                        Product = new Product() {ProductType = "wood", MatlCostPerSqFt = 4.00m, LaborCostPerSqFt = 3.00m},
                        State = new State() {StateAbbreviation = "OH", StateName = "Ohio", StateTaxRate = 0.07m},
                        Area = 400.00m//, LaborCost = , MaterialCost = 1600.00m, TaxCost = 196.00m,
                                       // TotalCost = 2996.00m
                    },
                    new Order() {OrderNumber = 2, CustomerName = "Stan Ball", Date = new DateTime(2016,05,29),
                        Product = new Product() {ProductType = "laminate", MatlCostPerSqFt = 2.75m, LaborCostPerSqFt = 2.50m},
                        State = new State() {StateAbbreviation = "IL", StateName = "Illinois", StateTaxRate = 0.0825m},
                        Area = 950.00m, //LaborCost = 2375.00m, MaterialCost = 2612.50m, TaxCost = 411.47m,
                        //TotalCost = 5398.97m
                    },
                    new Order() {OrderNumber = 3, CustomerName = "Paul Henry", Date = new DateTime(2016,05,29),
                        Product = new Product() {ProductType = "wood", MatlCostPerSqFt = 4.00m, LaborCostPerSqFt = 3.00m},
                        State = new State() {StateAbbreviation = "KY", StateName = "Kentucky", StateTaxRate = 0.059m},
                        Area = 825.00m, //LaborCost = 2475.00m, MaterialCost = 3300.00m, TaxCost = 340.73m,
                        //TotalCost = 6115.73m
                    }
                });
            }
        }


        public Order AddOrder(DateTime date, Order order)
        {
            //Dictionary<DateTime, List<Order>> _orders =
            
            
            if (_orders.ContainsKey(date))
            {
                order.OrderNumber = _orders[date].Count + 1;
                _orders[date].Add(order);
            }
            else
            {
                order.OrderNumber = 1;
                _orders.Add(date, new List<Order>() {order});
            }
            
            return order;
        }

        //public Order AddOrder(Order order)
        //{
        //    var dateReponse = CheckDate(order.Date);
        //    var orders = dateReponse.Data;
        //    if (orders != null)
        //    {
        //        order.OrderNumber++;
        //    }
        //    else
        //    {
        //        order.OrderNumber = 1;
        //        orders = new List<Order>();
        //    }

        //    orders.Add(order);
        //    //OverwriteFile(orders, order.Date);

        //    return order;
        //}

        public Order RemoveOrder(DateTime date, Order order)
        {
            //_orders.Remove(_orders[date].Where(o => o.OrderNumber = order.OrderNumber).FirstOrDefault());
            _orders[date].Remove(_orders[date].FirstOrDefault(o => o.OrderNumber == order.OrderNumber));

            return order;
        }

        //public Order RemoveOrder(Order order)
        //{
        //    //var dateReponse = CheckDate(order.Date);
        //    var orders = dateReponse.Data;
        //    if (orders != null)
        //    {
        //        //order.OrderNumber = orders.Count + 1;
        //        order.OrderNumber = 0;
        //    }
        //    else
        //    {
        //        order.OrderNumber = 1;
        //        orders = new List<Order>();
        //    }

        //    orders.Remove(order);
        //    OverwriteFile(orders, order.Date);

        //    return order;
        //}

        private void OverwriteFile(List<Order> orders, DateTime date)
        {

            Console.WriteLine("Date,Order Number,Customer Name,ProductType,Product cost per sq ft,Product labor cost per sq ft,State abbreviation,state name, state tax rate,Area,Labor Cost,Material Cost,Tax Cost,Total Order Cost");
            foreach (var order in orders)
            {
                Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13}",
                    order.Date,
                    order.OrderNumber,
                    order.CustomerName,
                    order.Product.ProductType,
                    order.Product.MatlCostPerSqFt,
                    order.Product.LaborCostPerSqFt,
                    order.State.StateAbbreviation,
                    order.State.StateName,
                    order.State.StateTaxRate,
                    order.Area,
                    order.LaborCost,
                    order.MaterialCost,
                    order.TaxCost,
                    order.TotalCost);
            }
        }


        public Response<List<Order>> CheckDate(DateTime date)
        {
            var response = new Response<List<Order>>();

            return response;
        }


        public Order EditOrder(DateTime date, Order order)
        {

            _orders[date].Remove(_orders[date].FirstOrDefault(o => o.OrderNumber == order.OrderNumber));

            if (_orders.ContainsKey(date))
            {
                order.OrderNumber = _orders[date].Count + 1;
                _orders[date].Add(order);
            }
            else
            {
                order.OrderNumber = 1;
                _orders.Add(date, new List<Order>() { order });
            }

            
           //orders.Add(date, new List<Order>() { order });
            return order;
        }

        public List<Order> GetAllOrders(DateTime date)
        {
            if (_orders.ContainsKey(date))
            {
                return _orders[date].ToList();
            }
            else
            {
                return new List<Order>();
            }
            
        }

        public Order DisplayOrder(int orderNumber, DateTime date)
        {
            List<Order> orders = GetAllOrders(date);
            return _orders[date].FirstOrDefault(o => o.OrderNumber == orderNumber);
        }

        //public void UpdateOrder(Order order)
        //{
        //    var orderToUpdate = orders.First(o => o.OrderNumber == order.OrderNumber);
        //    orderToUpdate.Product = order.Product;
        //    orderToUpdate.Area = order.Area;
        //    orderToUpdate.LaborCost = order.LaborCost;
        //    orderToUpdate.MaterialCost = order.MaterialCost;
        //    orderToUpdate.OrderNumber = order.OrderNumber;
        //    orderToUpdate.State.StateAbbreviation = order.State.StateAbbreviation;
        //    orderToUpdate.State.StateName = order.State.StateName;
        //    orderToUpdate.State.StateTaxRate = order.State.StateTaxRate;
        //    orderToUpdate.TaxCost = order.TaxCost;
        //    orderToUpdate.TotalCost = order.TotalCost;
        //    orderToUpdate.CustomerName = order.CustomerName;
        //    orderToUpdate.Date = order.Date;
        //}




    }
}
