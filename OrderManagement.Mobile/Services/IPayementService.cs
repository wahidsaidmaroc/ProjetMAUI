using OrderManagement.Mobile.Model;

namespace OrderManagement.Mobile.Services;

public interface IPayementService
{
    Task<IReadOnlyList<PayementDto>> GetPaymentsAsync(CancellationToken cancellationToken = default);

    Task<PayementDto?> CreatePaymentAsync(PayementDto payment, CancellationToken cancellationToken = default);
}
