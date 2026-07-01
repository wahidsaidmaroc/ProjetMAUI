namespace OrderManagement.Mobile;

public partial class SplashPage : ContentPage
{
	public SplashPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await Task.Delay(3000);

        if (Window is not null)
        {
            Window.Page = new AppShell();
        }
    }
}
