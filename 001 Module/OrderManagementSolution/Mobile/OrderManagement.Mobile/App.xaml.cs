namespace OrderManagement.Mobile;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new AppShell();
    }

    //protected override Window CreateWindow(IActivationState? activationState)
    //{
    //    return new Window(new MainPage());
    //}
}