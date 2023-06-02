using Microsoft.Maui.Graphics;

namespace SPBA.Views;

public partial class TestPage : ContentPage
{
	public TestPage()
	{
		InitializeComponent();

        var navigationPage = Application.Current.MainPage as NavigationPage;
        navigationPage.BarBackgroundColor = Color.FromArgb("#00e600");
        navigationPage.BarTextColor = Colors.White;
        _value = 0;

    }

    private readonly MainViewModel _viewModel;
    private double _value;

    private void Category_Selected(object sender, Controls.CategorySelectedEventArgs e)
        => _viewModel.CategorySelectedCommand.Execute(e);

    private void OnScrollViewScrolled(object sender, ScrolledEventArgs e)
    {
        if (e.ScrollY > _value)
        {
            //topContent.IsVisible = false;
            _value = e.ScrollY;
        }
        else
        {
            //topContent.IsVisible = true;
            _value = e.ScrollY;

        }
    }
}