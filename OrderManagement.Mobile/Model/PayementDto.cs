using System.Text.Json.Serialization;

namespace OrderManagement.Mobile.Model;

public class PayementDto
{
    [JsonPropertyName("paymentNbr")]
    public int PaymentNbr { get; set; }

    [JsonPropertyName("datePayement")]
    public string? DatePayement { get; set; }

    [JsonPropertyName("montant")]
    public decimal Montant { get; set; }
}
