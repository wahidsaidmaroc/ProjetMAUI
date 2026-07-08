using System.Net.Http.Json;
using System.Text.Json;
using OrderManagement.Mobile.Model;

namespace OrderManagement.Mobile.Services;

public class OrderService : IOrderService
{
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web);
    private readonly HttpClient _httpClient;

    public OrderService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IReadOnlyList<OrderDto>> GetOrdersAsync(CancellationToken cancellationToken = default)
    {
        var orders = await _httpClient.GetFromJsonAsync<List<OrderDto>>("api/Order", JsonOptions, cancellationToken);
        return orders ?? [];
    }

    public async Task<OrderDto?> CreateOrderAsync(OrderDto order, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Order", order, JsonOptions, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        return await response.Content.ReadFromJsonAsync<OrderDto>(JsonOptions, cancellationToken);
    }
}
