using OrderManagement.Mobile.Model;

namespace OrderManagement.Mobile.Services;

public interface IProductService
{
    Task<IReadOnlyList<Product>> GetProductsAsync(CancellationToken cancellationToken = default);
}
