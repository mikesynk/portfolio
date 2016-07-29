using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.BLL;
using SGFlooring.Models;

namespace SGFlooring.UI.Utility
{
    public static class OrderScreen
    {
        public static void PrintOrderDetails(Order order)
        {
            Console.WriteLine("=================================================================");
            Console.WriteLine("                Order Information");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine($"Order Number                   {order.OrderNumber}");
            Console.WriteLine($"Customer Name                  {order.CustomerName}");
            Console.WriteLine($"Product Type                   {order.Product.ProductType}");
            Console.WriteLine($"Material Cost per Sq. Ft.      {order.Product.MatlCostPerSqFt:c}");
            Console.WriteLine($"Labor Cost per Sq. Ft.         {order.Product.LaborCostPerSqFt:c}");
            Console.WriteLine($"State Name                     {order.State.StateName}");
            Console.WriteLine($"Tax Rate                       {order.State.StateTaxRate}%");
            Console.WriteLine($"Flooring Area                  {order.Area} sq. ft.");
            Console.WriteLine($"Material Cost                  {order.MaterialCost:c}");
            Console.WriteLine($"Labor Cost                     {order.LaborCost:c}");
            Console.WriteLine($"Tax Cost                       {order.TaxCost:c}");
            Console.WriteLine("________________________________________________________________");
            Console.WriteLine($"Total Order Cost               {order.TotalCost:c}\n");
            Console.WriteLine("================================================================");
        }

        public static void DisplayOrders(List<Order> orders )
        {
            foreach (var order in orders)
            {
                Console.WriteLine($"Order #: {order.OrderNumber}  \nCust. Name: {order.CustomerName}  \nProduct: {order.Product.ProductType} \nState: {order.State.StateName}\n");
            }
        }


        public static void DiplayOrder(Order order)
        {
            Console.Clear();
            Console.WriteLine("=================================================================");
            Console.WriteLine("                Order Information");
            Console.WriteLine("=================================================================");
            Console.WriteLine($"Order Number                   {order.OrderNumber}");
            Console.WriteLine($"Customer Name                  {order.CustomerName}");
            Console.WriteLine($"Product Type                   {order.Product.ProductType}");
            Console.WriteLine($"Material Cost per Sq. Ft.      {order.Product.MatlCostPerSqFt:c}");
            Console.WriteLine($"Labor Cost per Sq. Ft.         {order.Product.LaborCostPerSqFt:c}");
            Console.WriteLine($"State Name                     {order.State.StateName}");
            Console.WriteLine($"Tax Rate                       {order.State.StateTaxRate}%");
            Console.WriteLine($"Flooring Area                  {order.Area} sq. ft.");
            Console.WriteLine($"Material Cost                  {order.MaterialCost:c}");
            Console.WriteLine($"Labor Cost                     {order.LaborCost:c}");
            Console.WriteLine($"Tax Cost                       {order.TaxCost:c}");
            Console.WriteLine("________________________________________________________________");
            Console.WriteLine($"Total Order Cost               {order.TotalCost:c}\n");
        }

        public static void WorkflowErrorScreen(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
        }
    }
}
