namespace OrderManagement.Mobile.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
    }

    private void OnLoginClicked(object? sender, EventArgs e)
    {
        MessageLabel.Text = EmailEntry.Text == "admin"
            ? "Bienvenue !"
            : "Identifiants invalides";
    }

}