namespace SPBA.Views;

public partial class SecondPage : ContentPage
{
	public SecondPage()
	{
		InitializeComponent();

        var navigationPage = Application.Current.MainPage as NavigationPage;
        navigationPage.BarBackgroundColor = Color.FromArgb("#00e600");
        navigationPage.BarTextColor = Colors.White;
    }
}