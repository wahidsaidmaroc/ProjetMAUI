namespace OrderManagement.Mobile.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
        var email = new Entry { Placeholder = "Email" };
        var motDePasse = new Entry
        {
            Placeholder = "Mot de passe",
            IsPassword = true
        };
        var connexion = new Button { Text = "Se connecter" };
        var message = new Label { TextColor = Colors.Red };

        connexion.Clicked += (s, e) =>
            message.Text = (email.Text == "admin")
                ? "Bienvenue !" : "Identifiants invalides";

        Content = new VerticalStackLayout
        {
            Padding = 30,
            Spacing = 15,
            Children = { email, motDePasse, connexion, message }
        };

    }




}