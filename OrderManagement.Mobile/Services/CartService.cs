using System.Text.Json;
using Microsoft.Maui.Storage;
using OrderManagement.Mobile.Model;

namespace OrderManagement.Mobile.Services;

public class CartService : ICartService
{
    private const string StorageKey = "order-management-cart";
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web);
    private readonly List<CartItem> _items = [];

    public event EventHandler? CartChanged;

    public CartService()
    {
        Load();
    }

    public IReadOnlyList<CartItem> GetItems() => _items.AsReadOnly();

    public Task AddAsync(Product product, int quantity = 1)
    {
        if (quantity <= 0)
        {
            quantity = 1;
        }

        var existingItem = _items.FirstOrDefault(item => item.Product.Cle == product.Cle);
        if (existingItem is null)
        {
            _items.Add(new CartItem
            {
                Product = product,
                Quantity = quantity
            });
        }
        else
        {
            existingItem.Quantity += quantity;
        }

        Save();
        OnCartChanged();
        return Task.CompletedTask;
    }

    public Task UpdateQuantityAsync(int productKey, int quantity)
    {
        var existingItem = _items.FirstOrDefault(item => item.Product.Cle == productKey);
        if (existingItem is null)
        {
            return Task.CompletedTask;
        }

        if (quantity <= 0)
        {
            _items.Remove(existingItem);
        }
        else
        {
            existingItem.Quantity = quantity;
        }

        Save();
        OnCartChanged();
        return Task.CompletedTask;
    }

    public Task RemoveAsync(int productKey)
    {
        var existingItem = _items.FirstOrDefault(item => item.Product.Cle == productKey);
        if (existingItem is not null)
        {
            _items.Remove(existingItem);
            Save();
            OnCartChanged();
        }

        return Task.CompletedTask;
    }

    public Task ClearAsync()
    {
        _items.Clear();
        Save();
        OnCartChanged();
        return Task.CompletedTask;
    }

    public decimal GetTotal() => _items.Sum(item => item.Total);

    public int GetItemCount() => _items.Sum(item => item.Quantity);

    private void Load()
    {
        var json = Preferences.Default.Get(StorageKey, string.Empty);
        if (string.IsNullOrWhiteSpace(json))
        {
            return;
        }

        var items = JsonSerializer.Deserialize<List<CartItem>>(json, JsonOptions);
        if (items is null)
        {
            return;
        }

        _items.Clear();
        _items.AddRange(items);
    }

    private void Save()
    {
        var json = JsonSerializer.Serialize(_items, JsonOptions);
        Preferences.Default.Set(StorageKey, json);
    }

    private void OnCartChanged() => CartChanged?.Invoke(this, EventArgs.Empty);
}
