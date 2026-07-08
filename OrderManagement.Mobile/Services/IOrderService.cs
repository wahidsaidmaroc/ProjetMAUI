using OrderManagement.Mobile.Model;

namespace OrderManagement.Mobile.Services;

public interface IOrderService
{
    Task<IReadOnlyList<OrderDto>> GetOrdersAsync(CancellationToken cancellationToken = default);

    Task<OrderDto?> CreateOrderAsync(OrderDto order, CancellationToken cancellationToken = default);
}
