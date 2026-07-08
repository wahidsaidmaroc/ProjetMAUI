using System.Net.Http.Json;
using System.Text.Json;
using OrderManagement.Mobile.Model;

namespace OrderManagement.Mobile.Services;

public class PayementService : IPayementService
{
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web);
    private readonly HttpClient _httpClient;

    public PayementService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IReadOnlyList<PayementDto>> GetPaymentsAsync(CancellationToken cancellationToken = default)
    {
        var payments = await _httpClient.GetFromJsonAsync<List<PayementDto>>("api/Payement", JsonOptions, cancellationToken);
        return payments ?? [];
    }

    public async Task<PayementDto?> CreatePaymentAsync(PayementDto payment, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Payement", payment, JsonOptions, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        return await response.Content.ReadFromJsonAsync<PayementDto>(JsonOptions, cancellationToken);
    }
}
