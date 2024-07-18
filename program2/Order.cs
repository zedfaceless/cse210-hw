using System;
using System.Collections.Generic;

public class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
        products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public float CalculateTotalCost()
    {
        float totalCost = 0;
        foreach (var product in products)
        {
            totalCost += product.GetTotalCost();
        }
        if (customer.IsInUSA())
        {
            totalCost += 5;
        }
        else
        {
            totalCost += 35;
        }
        return totalCost;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "Packing Label:\n";
        foreach (var product in products)
        {
            packingLabel += $"Product: {product.Name}, ID: {product.ProductId}\n";
        }
        return packingLabel;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\nName: {customer.Name}\nAddress: {customer.Address.ToString()}";
    }
}

