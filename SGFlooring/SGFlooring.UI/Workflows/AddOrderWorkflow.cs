using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using SGFlooring.BLL;
using SGFlooring.Models;
using SGFlooring.UI.Interfaces;
using SGFlooring.UI.Utility;

namespace SGFlooring.UI.Workflows
{
    public class AddOrderWorkflow : IWorkflow
    {
        private Order _addOrder;
        public Order newOrder = new Order();

        public void Execute()
        {

            // confirm entry loop
            bool confirmEntry = true;
            do
            {
                newOrder.CustomerName = UserPrompts.GetStringFromuser("\nEnter Customer Name: ");
                newOrder.Date = UserPrompts.GetDateFromUser("\nEnter a Date (D/M/YY): ");

                newOrder.Product = UserPrompts.GetProductFromUser("\nEnter Letter of Product Type:" +
                                                                  "\n\tWood - W" +
                                                                  "\tCarpet - C" +
                                                                  "\tTile - T" +
                                                                  "\tLaminate - L");

                newOrder.State = UserPrompts.GetStateFromUser("\nEnter State Abbreviation:" +
                                                              "\n\tIndiana - IN" +
                                                              "\tMichigan - MI" +
                                                              "\tOhio - OH" +
                                                              "\tPennsylvania - PA");
                newOrder.Area = UserPrompts.GetDecimalFromUser("\nEnter the Flooring Area in Squared Feet: ");

                // summary and confirm entry prompt
                Console.Clear();
                Console.WriteLine("\t\tEntered Data Summary");
                Console.WriteLine($"\n\t\tCustomer Name:   {newOrder.CustomerName}");
                Console.WriteLine($"\t\tDate:            {newOrder.Date.Month}/{newOrder.Date.Day}/{newOrder.Date.Year}");
                Console.WriteLine($"\t\tProduct Type:    {newOrder.Product.ProductType}");
                Console.WriteLine($"\t\tState:           {newOrder.State.StateName}");
                Console.WriteLine($"\t\tFloor Area:      {newOrder.Area}");

                Console.WriteLine("\nDo you want to Commit this Order? (Y)es or (N) or (Q)uit?");

                string response = Console.ReadLine();

                if (response.Substring(0, 1).ToUpper() == "Q")
                {
                    UserPrompts.ReturnToMainMenu();
                }

                confirmEntry = UserPrompts.ConfirmationResponse(response);

            } while (!confirmEntry);
            
            // kick off BLL to add order then display 
            DisplayAddOrderInfo(newOrder);
        }

        private void DisplayAddOrderInfo(Order order)
        {
            var operation = new OrderOperations();
            var result = operation.AddOrder(order.Date, order);
            Console.Clear();
            if (result.Success)
            {
                OrderScreen.PrintOrderDetails(order);
            }
            else
            {
                OrderScreen.WorkflowErrorScreen(result.Message);
                LogUserInputErrors.LogInputErrors(result.Message, order.ToString());
            }

            UserPrompts.PressKeyToContinue();
        }

    }
}
