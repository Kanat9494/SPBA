namespace SPBA.Views.Controls;

public class CategorySelectedEventArgs : EventArgs
{
    public CategorySelectedEventArgs(Category category) => Category = category;

    public Category Category { get; set; }
}

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class CategoryRow : ContentView
{
	public CategoryRow()
	{
		InitializeComponent();

        SelectCategoryCommand = new Command(OnCategorySelected);
    }

    public static readonly BindableProperty CategoriesProperty =
        BindableProperty.Create(nameof(Categories), typeof(IEnumerable<Category>), typeof(CategoryRow), Enumerable.Empty<Category>());

    public IEnumerable<Category> Categories
    {
        get => (IEnumerable<Category>)GetValue(CategoriesProperty);
        set => SetValue(CategoriesProperty, value);
    }

    public ICommand SelectCategoryCommand { get; private set; }

    public event EventHandler<CategorySelectedEventArgs> CategorySelected;

    private void OnCategorySelected(object parameter)
    {
        if (parameter is Category category && category is not null)
        {
            CategorySelected?.Invoke(this, new CategorySelectedEventArgs(category));
        }
    }
}