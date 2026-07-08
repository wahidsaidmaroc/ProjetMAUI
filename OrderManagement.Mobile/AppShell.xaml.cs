using Microsoft.Extensions.DependencyInjection;
using OrderManagement.Mobile.Model;
using OrderManagement.Mobile.Services;
using OrderManagement.Mobile.Views;

namespace OrderManagement.Mobile
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            LoadDynamicCategories();
        }

        private async void LoadDynamicCategories()
        {
            try
            {
                var categoryService = App.Services.GetRequiredService<ICategoryService>();
                var categories = await categoryService.GetCategoriesAsync();

                foreach (var category in categories.OrderBy(category => category.Name))
                {
                    var title = category.Name ?? $"Catégorie {category.Cle}";
                    var flyoutItem = new FlyoutItem
                    {
                        Title = title,
                        Icon = "home.png",
                        Route = $"category-{category.Cle}"
                    };

                    flyoutItem.Items.Add(new ShellContent
                    {
                        Title = title,
                        ContentTemplate = new DataTemplate(() => new CategoryDetailPage(category))
                    });

                    Items.Add(flyoutItem);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Impossible de charger le menu dynamique des catégories : {ex}");
            }
        }
    }
}
