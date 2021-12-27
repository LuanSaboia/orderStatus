using enumProEx1.Entities;
using enumProEx1.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace enumProEx1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter cliente data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            Client client = new Client(name, email, birthDate);


            Console.WriteLine("Enter order data:");
            Console.Write("Status: ");
            OrderStatus os;
            Enum.TryParse(Console.ReadLine(), out os);
            Order order = new Order(DateTime.Now, os, client);

            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product name: ");
                string proName = Console.ReadLine();
                Console.Write("Product price: ");
                double proPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int proQuantity = int.Parse(Console.ReadLine());
                
                Product product = new Product(proName, proPrice);
                OrderItem orderItem = new OrderItem(proQuantity, proPrice, product);
                order.AddItem(orderItem);
            }

            Console.WriteLine();
            Console.WriteLine("ORDER SUMMARY");
            Console.WriteLine(order);
        }
    }
}
