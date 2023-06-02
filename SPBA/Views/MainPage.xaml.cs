namespace SPBA.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

        _value = 0;
        topContent.IsVisible = true;

        this.BindingContext = _viewModel = new MainViewModel();
    }

    private readonly MainViewModel _viewModel;
    private double _value;

    private void Category_Selected(object sender, Controls.CategorySelectedEventArgs e)
        => _viewModel.CategorySelectedCommand.Execute(e);

    private void OnScrollViewScrolled(object sender, ScrolledEventArgs e)
    {
        if (e.ScrollY > _value)
        {
            topContent.IsVisible = false;
            _value = e.ScrollY;
        }
        else
        {
            topContent.IsVisible = true;
            _value = e.ScrollY;

        }
    }

    private async void ToTestPage(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new TestPage());
	}
}