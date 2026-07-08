using System.Text.Json.Serialization;

namespace OrderManagement.Mobile.Model;

public class Product
{
    [JsonPropertyName("cle")]
    public int Cle { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("prix")]
    public decimal Price { get; set; }
}
