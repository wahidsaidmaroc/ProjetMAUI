namespace OrderManagement.Mobile.Model;

public class Product
{
    public int Id { get; set; }

    public string ProductCode { get; set; } = string.Empty;

    public string Description { get; set; } = "";

    public decimal Price { get; set; }

    public int Stock { get; set; }
}