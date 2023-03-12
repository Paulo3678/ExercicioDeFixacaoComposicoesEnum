using System;
using System.Globalization;
using ExercicioProposto.Entities;
using ExercicioProposto.Entities.Enum;

namespace ExercicioProposto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter cliente data:");
            Console.Write("Name: ");
            string clientName = Console.ReadLine();
            Console.Write("Email: ");
            string clientEmail = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime clientBirthDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Enter order data:");
            Console.Write("Status: ");
            OrderStatus orderStatus = Enum.Parse<OrderStatus>(Console.ReadLine());

            Client client = new Client(clientName, clientEmail, clientBirthDate);

            Console.Write("How many items to this order? ");
            int itemsToOrder = int.Parse(Console.ReadLine());
            Order order = new Order(orderStatus, client);

            Console.WriteLine();
            for (int i = 1; i <= itemsToOrder; i++)
            {
                Console.WriteLine($"Enter #{i} item data: ");
                Console.Write("Product name: ");
                string productName = Console.ReadLine();
                Console.Write("Product price: ");
                double productPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());


                Product product = new Product(productName, productPrice);
                OrderItem item = new OrderItem(quantity, productPrice, product);
                order.AddItem(item);
                
            }

            Console.WriteLine("Order sumary: ");
            Console.WriteLine(order.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}