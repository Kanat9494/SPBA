using SPBA.Services;
using System.Collections.ObjectModel;

namespace SPBA.ViewModels;

internal class MainViewModel : BaseViewModel 
{
    internal MainViewModel()
    {
        IsBusy = true;
        Categories = new ObservableCollection<Category>();
        PopularProducts = new ObservableCollection<PopularProduct>();
        CategorySelectedCommand = new Command<CategorySelectedEventArgs>(async (e) => await OnCategorySelected(e));

        Task.Run(async () =>
        {
            await LoadCategories();
            await LoadProducts();
        }).GetAwaiter().OnCompleted(() =>
        {
            IsBusy = false;
        });
    }

    public ObservableCollection<Category> Categories { get; set; }
    public ObservableCollection<PopularProduct> PopularProducts { get; set; }
    public Command<CategorySelectedEventArgs> CategorySelectedCommand { get; set; }

    private bool _isBusy;
    public bool IsBusy
    {
        get => _isBusy;
        set => SetProperty(ref _isBusy, value);
    }

    private async Task OnCategorySelected(CategorySelectedEventArgs e)
    {
        var category = HandleSelectedCategory(e);
        //if (category != null)
        //    await Shell.Current.GoToAsync("TestPage");

        if (category != null)
            await Application.Current.MainPage.Navigation.PushAsync(new SecondPage());
    }

    Category HandleSelectedCategory(CategorySelectedEventArgs e)
    {
        if (e is CategorySelectedEventArgs categorySelectedEventArs)
        {
            Category category = categorySelectedEventArs.Category;

            return category;
        }

        return null;
    }

    private async Task LoadCategories()
    {
        try
        {
            var response = await ContentService.Instance().GetItemsAsync<Category>("api/Categories/LoadCategories");

            if (response != null)
            {
                foreach (var item in response)
                    Categories.Add(item);
            }
        }
        catch
        {

        }
    }

    private async Task LoadProducts()
    {
        try
        {
            var response = await ContentService.Instance().GetItemsAsync<PopularProduct>("api/Products/LoadPopularProducts");

            if (response != null)
            {
                foreach (var item in response)
                    PopularProducts.Add(item);
            }
        }
        catch { }
    }
}
