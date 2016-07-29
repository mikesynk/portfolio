using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Data.Factories;
using SGFlooring.Data.Interfaces_Repositories;
using SGFlooring.Data.Repositories;
using SGFlooring.Models;

namespace SGFlooring.BLL
{
    public class OrderOperations
    {
        private readonly IOrderRepository _orderRepo;

        public OrderOperations(IOrderRepository orderRepo)
        {
            _orderRepo = OrderRepositoryFactory.GetOrderRepository();
        }

        public OrderOperations()
        {
            _orderRepo = OrderRepositoryFactory.GetOrderRepository();
        }

        public List<Order> GetAllOrders(DateTime date)
        {
            var orders = new List<Order>();
            orders = _orderRepo.GetAllOrders(date);
            return orders;
        }

        public Response<Order> RemoveOrder(DateTime date, Order order)
        {
            var repo = OrderRepositoryFactory.GetOrderRepository();
            var response = new Response<Order>();

            try
            {
                order = _orderRepo.RemoveOrder(date, order);

                if (order == null)
                {
                    response.Success = false;
                    response.Message = "Not an existing order";
                }
                else
                {
                    response.Success = true;
                    response.Data = order;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "There was an error. Please try again.";
            }

            return response;
        }

        public Response<Order> EditOrder(DateTime date, Order order)
        {
            var repo = OrderRepositoryFactory.GetOrderRepository();

            var editOrder = repo.EditOrder(date, order);

            var response = new Response<Order>();

            try
            {
                if (editOrder == null)
                {
                    response.Success = false;
                    response.Message = "Not an order";
                }
                else
                {
                    response.Success = true;
                    response.Data = order;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "There was an error. Please try again later.";
            }

            return response;
        }
       

        public Response<Order> AddOrder(DateTime date, Order order)
        {
            var repo = OrderRepositoryFactory.GetOrderRepository();

            var newOrder = repo.AddOrder(date, order);

            var response = new Response<Order>();

            try
            {
                if (newOrder == null)
                {
                    response.Success = false;
                    response.Message = "Not an order";
                }
                else
                {
                    response.Success = true;
                    response.Data = order;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "There was an error. Please try again later.";
            }
            return response;
        }

        public Response<List<Order>> RetrieveOrdersByDate(DateTime date)
        {
            var response = new Response<List<Order>>(new List<Order>());

            try
            {
                var orders = _orderRepo.GetAllOrders(date);

                if (orders.Count == 0)
                {
                    response.Success = false;
                    response.Message = "There are no orders on this date.";
                }
                else
                {
                    response.Success = true;
                    response.Data = orders;
                }
            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "There was an error. Please try again later.";
            }

            return response;
        }

        public Response<Order> RetrieveOrder(int orderNumber, DateTime date)
        {
            var response = new Response<Order>();
            var orders = _orderRepo.GetAllOrders(date);
            var order = orders.FirstOrDefault(o => o.OrderNumber == orderNumber);
            try
            {
                if (order == null)
                {
                    response.Success = false;
                    response.Message = "Order does not exist.";
                }
                else
                {
                    response.Success = true;
                    response.Data = order;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "There was an error. Please try again later.";
            }

            return response;
        }

    }
}
