using System.Text.Json.Serialization;

namespace OrderManagement.Mobile.Model;

public class Category
{
    [JsonPropertyName("cle")]
    public int Cle { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }
}
