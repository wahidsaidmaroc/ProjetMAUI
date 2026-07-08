using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using OrderManagement.Mobile.Model;
using OrderManagement.Mobile.Services;

namespace OrderManagement.Mobile.Views;

public partial class OrderPage : ContentPage, INotifyPropertyChanged
{
    private readonly ICartService _cartService;
    private readonly IOrderService _orderService;
    private string _totalText = string.Empty;
    private string _statusMessage = string.Empty;

    public event PropertyChangedEventHandler? PropertyChanged;

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

    public string StatusMessage
    {
        get => _statusMessage;
        set
        {
            if (_statusMessage == value) return;
            _statusMessage = value;
            OnPropertyChanged();
        }
    }

    public OrderPage()
    {
        InitializeComponent();
        BindingContext = this;
        _cartService = App.Services.GetRequiredService<ICartService>();
        _orderService = App.Services.GetRequiredService<IOrderService>();
        RefreshSummary();
    }

    private void RefreshSummary()
    {
        TotalText = $"Total à commander : {_cartService.GetTotal():0.00} MAD";
    }

    private async void OnCreateOrderClicked(object sender, EventArgs e)
    {
        var total = _cartService.GetTotal();
        if (total <= 0)
        {
            StatusMessage = "Votre panier est vide.";
            return;
        }

        var order = new OrderDto
        {
            OrderNbr = 0,
            OrderDate = DateTime.Now,
            Montant = total
        };

        var createdOrder = await _orderService.CreateOrderAsync(order);
        StatusMessage = createdOrder is null
            ? "Impossible de créer la commande."
            : $"Commande créée avec succès ({createdOrder.OrderNbr}).";
    }

    private async void OnGoPaymentClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("paiement");
    }

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
