using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.BLL;
using SGFlooring.Models;
using SGFlooring.UI.Interfaces;
using SGFlooring.UI.Utility;

namespace SGFlooring.UI.Workflows
{
    public class RemoveOrderWorkflow : IWorkflow
    {
        private Order _order;

        public void Execute()
        {
            var selectOrder = new Order();
            OrderOperations ops = new OrderOperations();


           DateTime date = UserPrompts.GetDateFromUser("Enter the Order Date: ");
            var orders = ops.RetrieveOrdersByDate(date);
            DisplayOrdersToRemoveByDate(date);

            // confirm order removal prompt
            bool confirmOrderNumber = true;
            do
            {
                selectOrder.OrderNumber = UserPrompts.GetIntFromUser("Enter the Order Number you'd like to remove: ");
                var orderToRemove = orders.Data.Where(o => o.OrderNumber == selectOrder.OrderNumber).FirstOrDefault();
                Console.Clear();
                Console.WriteLine($"Order Number to be Removed: {orderToRemove.OrderNumber}");
                Console.WriteLine();
                OrderScreen.PrintOrderDetails(orderToRemove);
                Console.WriteLine();
                Console.WriteLine("Do you want to Remove this Order? (Y)es or (N)o or (Q)uit?");

                string response = Console.ReadLine();

                if (response.Substring(0, 1).ToUpper() == "Q" || response.Substring(0,1).ToUpper() == "N")
                {
                    UserPrompts.ReturnToMainMenu();
                }

                confirmOrderNumber = UserPrompts.ConfirmationResponse(response);

            } while (!confirmOrderNumber);

            // kick off BLL for remove order process
            var order =  ops.RetrieveOrder(selectOrder.OrderNumber, date.Date).Data;
            if (order != null)
            {
                ops.RemoveOrder(date, order);
            }
            else
            {
                Console.WriteLine("This order doesn't exist.");
                string errorMessage = Console.ReadLine();
                LogUserInputErrors.LogInputErrors(errorMessage, date.ToString());
                UserPrompts.PressKeyToContinue();
            }
        }


    public void DisplayOrdersToRemoveByDate(DateTime date)
        {
            var operation = new OrderOperations();
            var result = operation.RetrieveOrdersByDate(date);
            Console.Clear();
            if (result.Success)
            {
                var orders = operation.RetrieveOrdersByDate(date).Data;
                OrderScreen.DisplayOrders( orders);
                Console.WriteLine();
            }
            else
            {
                OrderScreen.WorkflowErrorScreen(result.Message);
                LogUserInputErrors.LogInputErrors(result.Message, date.ToString());
            }
        }

    }
}
