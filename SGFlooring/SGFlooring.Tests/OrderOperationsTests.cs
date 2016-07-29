using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGFlooring.BLL;
using SGFlooring.Data.Repositories;
using SGFlooring.Models;

namespace SGFlooring.Tests
{
    [TestFixture]
    public class OrderOperationsTests
    {
        [Test]
        public void RemoveOrderTest()
        {
            var operation = new OrderOperations();
            var response = operation.RemoveOrder(new DateTime(2016, 05, 29), new Order());
            Assert.IsTrue(response.Success);
        }

        [Test]
        public void EditOrderTest()
        {
            var operation = new OrderOperations();
            var response = operation.EditOrder(new DateTime(2016, 05, 29), new Order());
            Assert.IsTrue(response.Success);
        }

        [Test]
        public void OrderNotFoundTest()
        {
            var operation = new OrderOperations();
            var response = operation.RetrieveOrdersByDate(new DateTime(2017, 05, 29));
            Assert.IsFalse(response.Success);
        }

        [Test]
        public void OrderFoundTest()
        {
            var operation = new OrderOperations();
            var response = operation.RetrieveOrdersByDate(new DateTime(2016, 05, 29));
            Assert.IsTrue(response.Success);
        }

        [Test]
        public void RetrieveOrderTest()
        {
            OrderRepository repo = new OrderRepository();
            Order order = repo.DisplayOrder(1, new DateTime(2016, 05, 29));
            Assert.AreEqual(1, order.OrderNumber);

        }

    }
}
