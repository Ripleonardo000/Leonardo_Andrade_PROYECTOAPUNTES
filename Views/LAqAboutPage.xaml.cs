namespace Leonardo_Andrade_PROYECTOAPUNTES.Views
    ;

public partial class LAqAboutPage : ContentPage
{
	public LAqAboutPage()
	{
		InitializeComponent();
	}

    private async void LearnMore_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.LAaBout about)
        {
            // Navigate to the specified URL in the system browser.
            await Launcher.Default.OpenAsync(about.MoreInfoUrl);
        }
    }
}