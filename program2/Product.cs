public class Product
{
    public string Name { get; set; }
    public string ProductId { get; set; }
    public float Price { get; set; }
    public int Quantity { get; set; }

    public Product(string name, string productId, float price, int quantity)
    {
        Name = name;
        ProductId = productId;
        Price = price;
        Quantity = quantity;
    }

    public float GetTotalCost()
    {
        return Price * Quantity;
    }
}
