using OrderManagement.Mobile.ViewModels;

namespace OrderManagement.Mobile.Views;

public partial class BindingExamplePage : ContentPage
{
    public BindingExamplePage()
    {
        InitializeComponent();
        // Le BindingContext permet à la page XAML de lire les propriétés du ViewModel.
        BindingContext = new BindingExampleViewModel();
    }
}
