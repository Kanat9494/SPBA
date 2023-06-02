namespace SPBA.Views;

public partial class MainView : ContentPage
{
	public MainView()
	{
		InitializeComponent();

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