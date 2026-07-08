using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using OrderManagement.Mobile.Model;
using OrderManagement.Mobile.Services;

namespace OrderManagement.Mobile.Views;

public partial class CartPage : ContentPage, INotifyPropertyChanged
{
    private readonly ICartService _cartService;

    public event PropertyChangedEventHandler? PropertyChanged;

    public ObservableCollection<CartItem> Items { get; } = new();

    private string _itemCountText = string.Empty;
    public string ItemCountText
    {
        get => _itemCountText;
        set
        {
            if (_itemCountText == value) return;
            _itemCountText = value;
            OnPropertyChanged();
        }
    }

    private string _totalText = string.Empty;
    public string TotalText
    {
        get => _totalText;
        set
        {
            if (_totalText == value) return;
            _totalText = value;
            OnPropertyChanged();
        }
    }

    public CartPage()
    {
        InitializeComponent();
        BindingContext = this;
        _cartService = App.Services.GetRequiredService<ICartService>();
        _cartService.CartChanged += OnCartChanged;
        RefreshCart();
    }

    protected override void OnDisappearing()
    {
        _cartService.CartChanged -= OnCartChanged;
        base.OnDisappearing();
    }

    private void OnCartChanged(object? sender, EventArgs e) => RefreshCart();

    private void RefreshCart()
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            Items.Clear();
            foreach (var item in _cartService.GetItems())
            {
                Items.Add(item);
            }

            ItemCountText = $"{_cartService.GetItemCount()} article(s)";
            TotalText = $"Total : {_cartService.GetTotal():0.00} MAD";
        });
    }

    private async void OnIncreaseClicked(object sender, EventArgs e)
    {
        if ((sender as Button)?.CommandParameter is not int productKey)
        {
            return;
        }

        var item = _cartService.GetItems().FirstOrDefault(x => x.Product.Cle == productKey);
        if (item is null)
        {
            return;
        }

        await _cartService.UpdateQuantityAsync(productKey, item.Quantity + 1);
    }

    private async void OnDecreaseClicked(object sender, EventArgs e)
    {
        if ((sender as Button)?.CommandParameter is not int productKey)
        {
            return;
        }

        var item = _cartService.GetItems().FirstOrDefault(x => x.Product.Cle == productKey);
        if (item is null)
        {
            return;
        }

        await _cartService.UpdateQuantityAsync(productKey, item.Quantity - 1);
    }

    private async void OnRemoveClicked(object sender, EventArgs e)
    {
        if ((sender as Button)?.CommandParameter is not int productKey)
        {
            return;
        }

        await _cartService.RemoveAsync(productKey);
    }

    private async void OnClearClicked(object sender, EventArgs e)
    {
        await _cartService.ClearAsync();
    }

    private async void OnCheckoutClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("commande");
    }

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
