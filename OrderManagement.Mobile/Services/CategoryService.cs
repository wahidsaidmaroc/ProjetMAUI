using System.Net.Http.Json;
using System.Text.Json;
using OrderManagement.Mobile.Model;

namespace OrderManagement.Mobile.Services;

public class CategoryService : ICategoryService
{
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web);
    private readonly HttpClient _httpClient;

    public CategoryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IReadOnlyList<Category>> GetCategoriesAsync(CancellationToken cancellationToken = default)
    {
        var categories = await _httpClient.GetFromJsonAsync<List<Category>>("api/Category", JsonOptions, cancellationToken);
        return categories ?? [];
    }
}
