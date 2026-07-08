using OrderManagement.Mobile.Model;

namespace OrderManagement.Mobile.Services;

public interface ICartService
{
    event EventHandler? CartChanged;

    IReadOnlyList<CartItem> GetItems();

    Task AddAsync(Product product, int quantity = 1);

    Task UpdateQuantityAsync(int productKey, int quantity);

    Task RemoveAsync(int productKey);

    Task ClearAsync();

    decimal GetTotal();

    int GetItemCount();
}
