using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.BLL;
using SGFlooring.UI.Interfaces;
using SGFlooring.UI.Utility;

namespace SGFlooring.UI.Workflows
{
    public class DisplayOrdersWorkflow : IWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            DateTime date = UserPrompts.GetDateFromUser("Please enter a date: ");
            DisplayOrdersByDate(date);
        }

        public void DisplayOrdersByDate(DateTime date)
        {
            var operation = new OrderOperations();
            var result = operation.RetrieveOrdersByDate(date);
            Console.Clear();
            if (result.Success)
            {
                foreach (var order in result.Data)
                {
                    OrderScreen.PrintOrderDetails(order);
                    Console.WriteLine();
                }
            }
            else
            {
                OrderScreen.WorkflowErrorScreen(result.Message);
            }

            UserPrompts.PressKeyToContinue();
        }
    }
}
