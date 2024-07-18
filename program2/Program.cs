using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        Address address1 = new Address("123 Elm St", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("John Doe", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "123", 799.99f, 1));
        order1.AddProduct(new Product("Mouse", "456", 19.99f, 2));

        Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Jane Smith", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Monitor", "789", 199.99f, 1));
        order2.AddProduct(new Product("Keyboard", "101", 49.99f, 1));
        order2.AddProduct(new Product("USB Cable", "102", 9.99f, 3));

        List<Order> orders = new List<Order> { order1, order2 };

        foreach (var order in orders)
        {
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total Cost: ${order.CalculateTotalCost():0.00}\n");
        }
    }
}
