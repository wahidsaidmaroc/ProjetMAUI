namespace OrderManagement.Mobile.Views;

public partial class CategoryPage : ContentPage
{
	public CategoryPage()
	{
		InitializeComponent();
        Label titre = new Label();
        titre.Text = "Category Page";
        titre.FontSize = 24;
        titre.TextColor = Colors.DarkBlue;
        titre.HorizontalOptions = LayoutOptions.Center;

        Content = titre;
    }
}