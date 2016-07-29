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
    public class EditOrderWorkflow : IWorkflow
    {
        private Order _order;

        public void Execute()
        {
            OrderOperations ops = new OrderOperations();
            DateTime date = UserPrompts.GetDateFromUser("Enter the Order Date: ");
            var orders = ops.RetrieveOrdersByDate(date);

            if (orders.Success == false)
            {
                Console.WriteLine("There are no Orders on this Date.");
                UserPrompts.PressKeyToContinue();
                UserPrompts.ReturnToMainMenu();
            }

            Console.Clear();
            OrderScreen.DisplayOrders(orders.Data);

            ///*return the list found*/DisplayOrdersToEditByDate(date);

            int ordernum = UserPrompts.GetIntOptions("Enter the Order Number you'd like to edit: ",orders.Data.Select(o=>o.OrderNumber).ToArray());
            var orderToEdit = orders.Data.Where(o => o.OrderNumber == ordernum).FirstOrDefault();

            // Confirm Entry Loop
            bool confirmEntry = true;
            do
            {
                // Display Order Number and Info for Fields that can be edited
                Console.Clear();
                Console.WriteLine($"\t\tOrder Number: {orderToEdit.OrderNumber}");
                Console.WriteLine("\t\t============");
                Console.WriteLine($"\t\tCustomer Name: {orderToEdit.CustomerName}");
                Console.WriteLine($"\t\tProduct Type: {orderToEdit.Product.ProductType}");
                Console.WriteLine($"\t\tState: {orderToEdit.State.StateName}");
                Console.WriteLine($"\t\tArea: {orderToEdit.Area}");
                //Console.ReadLine();

                // Prompt user for new info
                orderToEdit.CustomerName = UserPrompts.GetStringEditFromUser("\nEnter New Name (or Leave Blank and Press Enter): ", orderToEdit);
                orderToEdit.Product = UserPrompts.GetProductEditFromUser("\nEnter Letter of New Product Type (or Leave Blank and Press Enter):" +
                    "\n\tWood - W" +
                    "\tCarpet - C" +
                    "\tTile - T" +
                    "\tLaminate - L", orderToEdit.Product);
                orderToEdit.State = UserPrompts.GetStateEditFromUser("\nEnter New State Abbreviation (or Leave Blank and Press Enter):" +
                    "\n\tIndiana - IN" +
                    "\tMichigan - MI" +
                    "\tOhio - OH" +
                    "\tPennsylvania - PA", orderToEdit.State);
                orderToEdit.Area = UserPrompts.GetDecimalEditFromUser("\nEnter New Area to be Floored in Feet Squared " +
                                                                      "(or Leave Blank and Press Enter): ", orderToEdit.Area);

                // confirm entry prompt
                Console.Clear();
                Console.WriteLine("\t\tEntered Data Summary");
                Console.WriteLine($"\n\t\tCustomer Name:   {orderToEdit.CustomerName}");
                Console.WriteLine($"\t\tProduct Type:    {orderToEdit.Product.ProductType}");
                Console.WriteLine($"\t\tState:           {orderToEdit.State.StateName}");
                Console.WriteLine($"\t\tFloor Area:      {orderToEdit.Area} sq. ft.");
                Console.WriteLine("\nDo you want to commit these edits? (Y)es or (N)o or (Q)uit");

                string response = Console.ReadLine();

                if (response.Substring(0, 1).ToUpper() == "Q")
                {
                    UserPrompts.ReturnToMainMenu();
                }

                confirmEntry = UserPrompts.ConfirmationResponse(response);

            } while (!confirmEntry);

            // kick off process to BLL to edit order
            var result = ops.EditOrder(orderToEdit.Date, orderToEdit);
            Console.Clear();
            if (result.Success)
            {
                OrderScreen.PrintOrderDetails(orderToEdit);

            }
            else
            {
                OrderScreen.WorkflowErrorScreen(result.Message);
                LogUserInputErrors.LogInputErrors(result.Message, orderToEdit.ToString());
            }


            UserPrompts.PressKeyToContinue();


        }

        

        
    }
}
