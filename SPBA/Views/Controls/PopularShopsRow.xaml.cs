namespace SPBA.Views.Controls;

public partial class PopularShopsRow : ContentView
{
	public PopularShopsRow()
	{
		InitializeComponent();
	}

    public static readonly BindableProperty PopularShopsProperty =
        BindableProperty.Create(nameof(PopularShops), typeof(IEnumerable<PopularProduct>), typeof(PopularShopsRow), Enumerable.Empty<PopularProduct>());

    public IEnumerable<PopularProduct> PopularShops
    {
        get => (IEnumerable<PopularProduct>)GetValue(PopularShopsProperty);
        set => SetValue(PopularShopsProperty, value);
    }
}