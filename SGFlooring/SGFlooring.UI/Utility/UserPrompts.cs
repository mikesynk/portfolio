using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.BLL;
using SGFlooring.Models;
using SGFlooring.UI.Workflows;

namespace SGFlooring.UI.Utility
{
    public static class UserPrompts
    {
        
        public static int GetIntOptions(string message, int[] options)
        {
            int result = 0;

            while (!options.Contains(result=GetIntFromUser(message)))
            {
                Console.WriteLine("\nThat option is not available.");
                PressKeyToContinue();
                string errorMessage = "That option is not available";
                LogUserInputErrors.LogInputErrors(errorMessage, options.ToString());
            }

            return result;
        }

        public static string GetStringFromuser(string message)
        {
            do
            {
                Console.WriteLine(message);
                string userInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(userInput))
                {
                    return userInput;
                }
                else
                {
                    Console.WriteLine("\nThis field cannot be blank...");
                    PressKeyToContinue();
                    string errorMessage = "Please enter this field";
                    LogUserInputErrors.LogInputErrors(errorMessage, userInput);
                }
            } while (true);
        }

        public static string GetStringEditFromUser(string message, Order order)
        {
            do
            {
                Console.WriteLine(message);
                string userInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(userInput))
                {
                    return userInput;
                }
                else
                {
                    return order.CustomerName;
                }

            } while (true);
        }

        public static decimal GetDecimalFromUser(string message)
        {
            do
            {
                Console.WriteLine(message);
                bool isValid = true;
                string userInput = Console.ReadLine();
                decimal value = 0;

                if (decimal.TryParse(userInput, out value) && value >= 0)
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("\nPlease enter a positive number");
                    string errorMessage = "Please enter a positive number";
                    LogUserInputErrors.LogInputErrors(errorMessage, userInput);
                    PressKeyToContinue();
                }
            } while (true);
        }

        public static decimal GetDecimalEditFromUser(string message, decimal originalDeimal)
        {
            do
            {
                Console.WriteLine(message);
                bool isValid = true;
                string userInput = Console.ReadLine();
                decimal value = 0;

                if (string.IsNullOrEmpty(userInput))
                {
                    return originalDeimal;
                }
                else if (decimal.TryParse(userInput, out value) && value >= 0)
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("\nPlease enter a positive number");
                    string errorMessage = "Please enter a positive number";
                    LogUserInputErrors.LogInputErrors(errorMessage, userInput);
                    PressKeyToContinue();
                }
            } while (true);
        }

        public static int GetIntFromUser(string message)
        {
            do
            {
                Console.WriteLine(message);
                string userInput = Console.ReadLine();
                int value;
                bool isValid = true;

                if (int.TryParse(userInput, out value) && value >= 0)
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("\nPlease enter a positve number");
                    string errorMessage = Console.ReadLine();
                    LogUserInputErrors.LogInputErrors(errorMessage, userInput);
                    PressKeyToContinue();
                }
            } while (true);
        }

        public static DateTime GetDateFromUser(string message)
        {
            do
            {
                Console.WriteLine(message);
                DateTime userInput;
                string input = Console.ReadLine();
                if (DateTime.TryParse(input, out userInput))
                {
                    return userInput;
                }
                else
                {
                    Console.WriteLine("\nThe date must be in proper format.");
                    string errorMessage = "Please enter a date";
                    LogUserInputErrors.LogInputErrors(errorMessage, input);
                    PressKeyToContinue();
                }

            } while (true);
        }

        public static State GetStateFromUser(string message)
        {
            do
            {
                Console.WriteLine(message);

                StateOperations stateOperation = new StateOperations();
                State state = stateOperation.GetState(Console.ReadLine());
                string userInput = state.ToString();


                if ((state.StateAbbreviation.ToUpper() == "OH") ||
                        (state.StateAbbreviation.ToUpper() == "PA") ||
                        (state.StateAbbreviation.ToUpper() == "MI") ||
                        (state.StateAbbreviation.ToUpper() == "IN"))
                {
                    return state;
                }
                else
                {
                    Console.WriteLine("\nThat is not a valid state");
                    string errorMessage = "That is not a valid state";
                    LogUserInputErrors.LogInputErrors(errorMessage, userInput);
                    PressKeyToContinue();
                }


            } while (true);
        }

        public static State GetStateEditFromUser(string message, State currentState)
        {
            do
            {
                Console.WriteLine(message);

                StateOperations stateOperation = new StateOperations();
                string userInput = Console.ReadLine();
                State state = stateOperation.GetState(userInput);

                if (string.IsNullOrEmpty(userInput))
                {

                    return currentState;
                }
                else if ((state.StateAbbreviation.ToUpper() == "OH") ||
                        (state.StateAbbreviation.ToUpper() == "PA") ||
                        (state.StateAbbreviation.ToUpper() == "MI") ||
                        (state.StateAbbreviation.ToUpper() == "IN"))
                {
                    return state;
                }
                else
                {
                    Console.WriteLine("\nThat is not a valid state");
                    string errorMessage = "That is not a valid state";
                    LogUserInputErrors.LogInputErrors(errorMessage, userInput);
                    PressKeyToContinue();
                }


            } while (true);
        }

        public static State Get111StateEditFromUser(string message, State currentState)
        {
            do
            {
                Console.WriteLine(message);

                StateOperations stateOperation = new StateOperations();
                string userInput = Console.ReadLine();
                State state = stateOperation.GetState(userInput);
                
                if (string.IsNullOrEmpty(userInput))
                {

                    return currentState;
                }
                else if ((state.StateAbbreviation.ToUpper() == "OH") ||
                        (state.StateAbbreviation.ToUpper() == "PA") ||
                        (state.StateAbbreviation.ToUpper() == "MI") ||
                        (state.StateAbbreviation.ToUpper() == "IN"))
                {
                    return state;
                }
                else
                {
                    Console.WriteLine("\nThat is not a valid state");
                    string errorMessage = "That is not a valid state";
                    LogUserInputErrors.LogInputErrors(errorMessage, userInput);
                    PressKeyToContinue();
                }


            } while (true);
        }


        public static Product GetProductFromUser(string message)
        {
            do
            {
                Console.WriteLine(message);

                ProductOperations productOperation = new ProductOperations();

                string userInput = Console.ReadLine();


                if (userInput.ToUpper() == "W")
                {
                    Product product = productOperation.GetProduct("Wood");
                    return product;
                }else if (userInput.ToUpper() == "C")
                {
                    Product product = productOperation.GetProduct("Carpet");
                    return product;
                }
                else if (userInput.ToUpper() == "T")
                {
                    Product product = productOperation.GetProduct("Tile");
                    return product;
                }
                else if (userInput.ToUpper() == "L")
                {
                    Product product = productOperation.GetProduct("Laminate");
                    return product;
                }
                else
                {
                    Console.WriteLine("\nThat is not a valid product");
                    string errorMessage = "That is not a vald product";
                    LogUserInputErrors.LogInputErrors(errorMessage, userInput);
                    PressKeyToContinue();
                }

            } while (true);

        }

        public static Product GetProductEditFromUser(string message, Product currentProduct)
        {
            do
            {
                Console.WriteLine(message);

                ProductOperations productOperation = new ProductOperations();

                string userInput = Console.ReadLine();


                if (string.IsNullOrEmpty(userInput))
                {
                    return currentProduct;
                }
                else if (userInput.ToUpper() == "W")
                {
                    Product product = productOperation.GetProduct("Wood");
                    return product;
                }
                else if (userInput.ToUpper() == "C")
                {
                    Product product = productOperation.GetProduct("Carpet");
                    return product;
                }
                else if (userInput.ToUpper() == "T")
                {
                    Product product = productOperation.GetProduct("Tile");
                    return product;
                }
                else if (userInput.ToUpper() == "L")
                {
                    Product product = productOperation.GetProduct("Laminate");
                    return product;
                }
                else
                {
                    Console.WriteLine("\nThat is not a valid product");
                    string errorMessage = "That is not a vald product";
                    LogUserInputErrors.LogInputErrors(errorMessage, userInput);
                    PressKeyToContinue();
                }

            } while (true);

        }

        public static bool ConfirmationResponse(string response)
        {
            switch (response.ToUpper())
            {
                case "Y":
                    return true;
                case "N":
                    return false;
                default:
                    Console.WriteLine("That was not valid response.");
                    return false;
            }

        }

        public static void PressKeyToContinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public static void ReturnToMainMenu()
        {
            MainMenu menu = new MainMenu();
            menu.Execute();
        }

    }
}
