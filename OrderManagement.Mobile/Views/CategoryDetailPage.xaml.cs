using OrderManagement.Mobile.Model;

namespace OrderManagement.Mobile.Views;

public partial class CategoryDetailPage : ContentPage
{
    public string CategoryName { get; }
    public string CategoryDescription { get; }

    public CategoryDetailPage(Category category)
    {
        InitializeComponent();
        CategoryName = category.Name ?? "Catégorie";
        CategoryDescription = category.Description ?? string.Empty;
        BindingContext = this;
    }

    private async void OnProductsClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//produits");
    }
}
