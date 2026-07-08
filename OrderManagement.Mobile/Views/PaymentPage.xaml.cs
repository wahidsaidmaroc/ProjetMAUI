using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using OrderManagement.Mobile.Model;
using OrderManagement.Mobile.Services;

namespace OrderManagement.Mobile.Views;

public partial class PaymentPage : ContentPage, INotifyPropertyChanged
{
    private readonly ICartService _cartService;
    private readonly IPayementService _payementService;
    private string _totalText = string.Empty;
    private string _statusMessage = string.Empty;
    private string _paymentNumber = string.Empty;

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

    public string PaymentNumber
    {
        get => _paymentNumber;
        set
        {
            if (_paymentNumber == value) return;
            _paymentNumber = value;
            OnPropertyChanged();
        }
    }

    public PaymentPage()
    {
        InitializeComponent();
        BindingContext = this;
        _cartService = App.Services.GetRequiredService<ICartService>();
        _payementService = App.Services.GetRequiredService<IPayementService>();
        RefreshSummary();
    }

    private void RefreshSummary()
    {
        TotalText = $"Montant à payer : {_cartService.GetTotal():0.00} MAD";
    }

    private async void OnPayClicked(object sender, EventArgs e)
    {
        var total = _cartService.GetTotal();
        if (total <= 0)
        {
            StatusMessage = "Le panier est vide.";
            return;
        }

        var payment = new PayementDto
        {
            PaymentNbr = int.TryParse(PaymentNumber, out var number) ? number : 0,
            DatePayement = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            Montant = total
        };

        var createdPayment = await _payementService.CreatePaymentAsync(payment);
        StatusMessage = createdPayment is null
            ? "Paiement impossible."
            : "Paiement enregistré avec succès.";

        if (createdPayment is not null)
        {
            await _cartService.ClearAsync();
        }
    }

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
