using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using OrderManagement.Mobile.Model;
using OrderManagement.Mobile.Services;

namespace OrderManagement.Mobile.Views;

public partial class ProductPage : ContentPage, INotifyPropertyChanged
{
    private readonly ICartService _cartService;
    private readonly IProductService _productService;
    private bool _isBusy;
    private string _errorMessage = string.Empty;
    private bool _hasLoaded;

    public event PropertyChangedEventHandler? PropertyChanged;

    public ObservableCollection<Product> Products { get; } = new();

    public bool IsBusy
    {
        get => _isBusy;
        set
        {
            if (_isBusy == value)
            {
                return;
            }

            _isBusy = value;
            OnPropertyChanged();
        }
    }

    public string ErrorMessage
    {
        get => _errorMessage;
        set
        {
            if (_errorMessage == value)
            {
                return;
            }

            _errorMessage = value;
            OnPropertyChanged();
        }
    }

    public ProductPage()
    {
        InitializeComponent();
        BindingContext = this;
        _cartService = App.Services.GetRequiredService<ICartService>();
        _productService = App.Services.GetRequiredService<IProductService>();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (_hasLoaded)
        {
            return;
        }

        _hasLoaded = true;
        await LoadProductsAsync();
    }

    private async Task LoadProductsAsync()
    {
        try
        {
            IsBusy = true;
            ErrorMessage = string.Empty;
            Products.Clear();

            var products = await _productService.GetProductsAsync();

            foreach (var product in products.OrderBy(product => product.Name))
            {
                Products.Add(product);
            }

            if (Products.Count == 0)
            {
                ErrorMessage = "Aucun produit retourné par l'API.";
            }
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Impossible de charger les produits : {ex.Message}";
        }
        finally
        {
            IsBusy = false;
        }
    }

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private async void OnAddToCartClicked(object sender, EventArgs e)
    {
        if ((sender as Button)?.CommandParameter is not Product product)
        {
            return;
        }

        await _cartService.AddAsync(product);
        await DisplayAlert("Panier", $"{product.Name} ajouté au panier.", "OK");
    }

    private async void OnGoCartClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("panier");
    }
}
