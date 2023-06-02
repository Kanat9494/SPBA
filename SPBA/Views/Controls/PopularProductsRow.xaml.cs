namespace SPBA.Views.Controls;

public partial class PopularProductsRow : ContentView
{
	public PopularProductsRow()
	{
		InitializeComponent();
	}

    public static readonly BindableProperty ProductsProperty =
       BindableProperty.Create(nameof(Products), typeof(IEnumerable<PopularProduct>), typeof(PopularProductsRow), Enumerable.Empty<PopularProduct>());

    public IEnumerable<PopularProduct> Products
    {
        get => (IEnumerable<PopularProduct>)GetValue(ProductsProperty);
        set => SetValue(ProductsProperty, value);
    }
}