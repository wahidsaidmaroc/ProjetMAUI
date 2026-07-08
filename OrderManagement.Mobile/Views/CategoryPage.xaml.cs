using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using OrderManagement.Mobile.Model;
using OrderManagement.Mobile.Services;

namespace OrderManagement.Mobile.Views;

public partial class CategoryPage : ContentPage, INotifyPropertyChanged
{
    private readonly ICategoryService _categoryService;
    private bool _isBusy;
    private string _errorMessage = string.Empty;
    private bool _hasLoaded;

    public event PropertyChangedEventHandler? PropertyChanged;

    public ObservableCollection<Category> Categories { get; } = new();

    public bool IsBusy
    {
        get => _isBusy;
        set
        {
            if (_isBusy == value)
            {
                return;
            }

            _isBusy = value;
            OnPropertyChanged();
        }
    }

    public string ErrorMessage
    {
        get => _errorMessage;
        set
        {
            if (_errorMessage == value)
            {
                return;
            }

            _errorMessage = value;
            OnPropertyChanged();
        }
    }


    public CategoryPage()
    {
        InitializeComponent();
        BindingContext = this;
        _categoryService = App.Services.GetRequiredService<ICategoryService>();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (_hasLoaded)
        {
            return;
        }

        _hasLoaded = true;
        await LoadCategoriesAsync();
    }

    private async Task LoadCategoriesAsync()
    {
        try
        {
            IsBusy = true;
            ErrorMessage = string.Empty;
            Categories.Clear();

            var categories = await _categoryService.GetCategoriesAsync();

            foreach (var category in categories.OrderBy(category => category.Name))
            {
                Categories.Add(category);
            }

            if (Categories.Count == 0)
            {
                ErrorMessage = "Aucune catégorie retournée par l'API.";
            }
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Impossible de charger les catégories : {ex.Message}";
        }
        finally
        {
            IsBusy = false;
        }
    }

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private async void OnCategorySelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not Category category)
        {
            return;
        }

        if (sender is CollectionView collectionView)
        {
            collectionView.SelectedItem = null;
        }

        await Navigation.PushAsync(new CategoryDetailPage(category));
    }
}
