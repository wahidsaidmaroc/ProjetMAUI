using System.Net.Http.Json;
using System.Text.Json;
using OrderManagement.Mobile.Model;

namespace OrderManagement.Mobile.Services;

public class ProductService : IProductService
{
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web);
    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IReadOnlyList<Product>> GetProductsAsync(CancellationToken cancellationToken = default)
    {
        var products = await _httpClient.GetFromJsonAsync<List<Product>>("api/Product", JsonOptions, cancellationToken);
        return products ?? [];
    }
}
