using OrderManagement.Mobile.Model;
using System.Collections.ObjectModel;

namespace OrderManagement.Mobile.Views;

public partial class ProductPage : ContentPage
{
	public ProductPage()
	{
		InitializeComponent();
        BindingContext = this;

    }

    public ObservableCollection<Product> Products { get; set; }
    = new()
{
    new Product
    {
        Id = 1,
        ProductCode = "PROD-001",
        Description = "Laptop Dell",
        Price = 8500,
        Stock = 25
    },

    new Product
    {
        Id = 2,
        ProductCode = "PROD-002",
        Description = "HP EliteBook",
        Price = 9200,
        Stock = 15
    }
};
}