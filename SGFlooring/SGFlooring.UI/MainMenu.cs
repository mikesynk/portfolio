using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.UI.Interfaces;
using SGFlooring.UI.Utility;
using SGFlooring.UI.Workflows;

namespace SGFlooring.UI
{
    public class MainMenu
    {
        public void Execute()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("SG Corp Order Entry System");
                Console.WriteLine("==========================");
                Console.WriteLine("1. Display Orders");
                Console.WriteLine("2. Add an Order");
                Console.WriteLine("3. Edit an Order");
                Console.WriteLine("4. Remove an Order");
                Console.WriteLine("5. Quit");

                string input = UserPrompts.GetStringFromuser("Enter desired number (example: 1)");
                    
                ProcessChoice(input);
            } while (true);
        }

        public void ProcessChoice(string choice)
        {
            IWorkflow workflow = null;
            switch (choice)
            {
                case "1":
                    workflow = new DisplayOrdersWorkflow();
                    break;
                case "2":
                    workflow = new AddOrderWorkflow();
                    break;
                case "3":
                    workflow = new EditOrderWorkflow();
                    break;
                case "4":
                    workflow = new RemoveOrderWorkflow();
                    break;
                case "5":
                    workflow = new ExitApplicationWorkflow();
                    break;
            }
            if (workflow != null) workflow.Execute();
        }
    }
}
