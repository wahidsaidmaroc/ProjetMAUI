namespace OrderManagement.Mobile.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        ErrorLabel.IsVisible = false;
        ErrorLabel.Text = string.Empty;

        if (string.IsNullOrWhiteSpace(EmailEntry.Text) ||
            string.IsNullOrWhiteSpace(PasswordEntry.Text))
        {
            ErrorLabel.Text = "Veuillez remplir tous les champs.";
            ErrorLabel.IsVisible = true;
            return;
        }

        // Exemple simple pour TP
        if (EmailEntry.Text == "admin@test.com" && PasswordEntry.Text == "1234")
        {
            await DisplayAlert("Succès", "Connexion réussie.", "OK");

            // Navigation vers HomePage
            await Navigation.PushAsync(new MainPage());
        }
        else
        {
            ErrorLabel.Text = "Email ou mot de passe incorrect.";
            ErrorLabel.IsVisible = true;
        }
    }
}