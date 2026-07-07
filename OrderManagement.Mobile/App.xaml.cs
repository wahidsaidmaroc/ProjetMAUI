namespace OrderManagement.Mobile;

public partial class App : Application
{
    public static IServiceProvider Services => Current?.Handler?.MauiContext?.Services
        ?? throw new InvalidOperationException("Le conteneur de services MAUI n'est pas disponible.");

    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new SplashPage());
    }
}