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
    public class OrderRepository : IOrderRepository
    {
        private string _filepath = @"DataFiles\";

        public List<Order> GetAllOrders(DateTime date)
        {

            List<Order> results = new List<Order>();

            _filepath = "DataFiles/Orders_" + ConvertDateInGoodFormatString(date) + ".txt";
            if (File.Exists(_filepath))
            {
                var rows = File.ReadAllLines(_filepath);

                for (int i = 1; i < rows.Length; i++)
                {
                    var columns = rows[i].Split(',');

                    var order = new Order();
                    order.Date = DateTime.Parse(columns[0]);
                    order.OrderNumber = int.Parse(columns[1]);
                    order.CustomerName = columns[2];
                    order.Product = new Product();
                    order.State = new State();
                    order.Product.ProductType = columns[3];
                    order.Product.MatlCostPerSqFt = decimal.Parse(columns[4]);
                    order.Product.LaborCostPerSqFt = decimal.Parse(columns[5]);
                    order.State.StateAbbreviation = (columns[6]);
                    order.State.StateName = columns[7];
                    order.State.StateTaxRate = decimal.Parse(columns[8]);
                    order.Area = decimal.Parse(columns[9]);

                    results.Add(order);
                }
            }

            return results;
        }

        public Order AddOrder(DateTime date, Order order)
        {
            var dateReponse = CheckDate(order.Date); 
            var orders = dateReponse.Data;
            if (orders != null)
            {
                order.OrderNumber = orders.Max(o => o.OrderNumber) + 1;
            }
            else
            {
                order.OrderNumber = 1;
                orders = new List<Order>();
            }

            orders.Add(order);
            OverwriteFile(orders, order.Date);
            return order;
        }

        public Order RemoveOrder(DateTime date, Order order) 
        {
           var orders = GetAllOrders(date);
            orders.Remove(orders.First(o => o.OrderNumber == order.OrderNumber));

            OverwriteFile(orders, order.Date);

            return order;
        }

        public Response<List<Order>> CheckDate(DateTime date)
        {
            var response = new Response<List<Order>>();

            _filepath = "DataFiles/Orders_" + ConvertDateInGoodFormatString(date) + ".txt";
            if (File.Exists(_filepath))
            {
                response.Data = GetAllOrders(date);
                response.Success = true;
            }
            else
            {
                response.Message = "No orders for this date.";
                response.Success = false;
            }
            return response;
        }

        private void OverwriteFile(List<Order> orders, DateTime date)
        {
            _filepath = "DataFiles/Orders_" + ConvertDateInGoodFormatString(date) + ".txt";

            if (File.Exists(_filepath))
                File.Delete(_filepath);

            var sortedOrders = orders.OrderBy(o => o.OrderNumber);

            using (var writer = File.CreateText(_filepath))
            {

                writer.WriteLine("Date,Order Number,Customer Name,ProductType,Product cost per sq ft," +
                                 "Product labor cost per sq ft,State abbreviation,state name, " +
                                 "state tax rate,Area,Labor Cost,Material Cost,Tax Cost,Total Order Cost");

                foreach (var order in sortedOrders)
                {
                    writer.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13}",
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
        }

        public void UpdateOrder(Order order, DateTime date)
        {
            var orders = GetAllOrders();

            var orderToUpdate = orders.First(o => o.OrderNumber == order.OrderNumber);

            orderToUpdate.Date = order.Date;
            orderToUpdate.OrderNumber = order.OrderNumber;
            orderToUpdate.CustomerName = order.CustomerName;
            orderToUpdate.Product.ProductType = order.Product.ProductType;
            orderToUpdate.Product.MatlCostPerSqFt = order.Product.MatlCostPerSqFt;
            orderToUpdate.Product.LaborCostPerSqFt = order.Product.LaborCostPerSqFt;
            orderToUpdate.State.StateAbbreviation = order.State.StateAbbreviation;
            orderToUpdate.State.StateName = order.State.StateName;
            orderToUpdate.State.StateTaxRate = order.State.StateTaxRate;
            orderToUpdate.Area = order.Area;

            OverwriteFile(orders, date);
        }

        public Order EditOrder(DateTime date, Order order)
        {
            var dateReponse = CheckDate(order.Date);
            var orders = dateReponse.Data;

            orders.Remove(orders.First(o => o.OrderNumber == order.OrderNumber));

            orders.Add(order);
            OverwriteFile(orders, order.Date);
            return order;
        }

        public Order DisplayOrder(int orderNumber, DateTime date)
        {
            List<Order> orders = GetAllOrders();
            return orders.FirstOrDefault(o => o.OrderNumber == orderNumber);
        }

        private List<Order> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        private string ConvertDateInGoodFormatString(DateTime date)
        {
            var result = "";
            if (date.Month < 10)
            {
                result = "0" + date.Month.ToString();
            }
            else
            {
                result = date.Month.ToString();
            }
            if (date.Day < 10)
            {
                result += "0" + date.Day.ToString();
            }
            else
            {
                result += date.Day.ToString();
            }
            result += date.Year.ToString();
            return result;
        }

    }
}
