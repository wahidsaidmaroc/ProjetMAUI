using System.Text.Json.Serialization;

namespace OrderManagement.Mobile.Model;

public class OrderDto
{
    [JsonPropertyName("cle")]
    public int Cle { get; set; }

    [JsonPropertyName("orderNbr")]
    public int OrderNbr { get; set; }

    [JsonPropertyName("orderDate")]
    public DateTime OrderDate { get; set; } = DateTime.Now;

    [JsonPropertyName("montant")]
    public decimal Montant { get; set; }
}
