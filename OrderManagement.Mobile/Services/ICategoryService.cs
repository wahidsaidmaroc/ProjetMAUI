using OrderManagement.Mobile.Model;

namespace OrderManagement.Mobile.Services;

public interface ICategoryService
{
    Task<IReadOnlyList<Category>> GetCategoriesAsync(CancellationToken cancellationToken = default);
}
