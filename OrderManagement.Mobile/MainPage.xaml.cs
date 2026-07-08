using System.Collections.ObjectModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Dispatching;
using OrderManagement.Mobile.Model;
using OrderManagement.Mobile.Services;

namespace OrderManagement.Mobile;

public partial class MainPage : ContentPage
{
    private readonly IProductService _productService;
    private readonly IDispatcherTimer _slideTimer;
    private readonly CarouselView _slidesCarousel;
    private bool _hasLoaded;

    public ObservableCollection<HomeSlide> Slides { get; } = new()
    {
        new HomeSlide
        {
            Title = "Jusqu'à -50% sur une sélection",
            Subtitle = "Les meilleures offres de la semaine dans votre boutique mobile.",
            Image = "home.png"
        },
        new HomeSlide
        {
            Title = "Nouveautés à découvrir",
            Subtitle = "Explorez le catalogue avec un style clair et rapide.",
            Image = "dotnet_bot.png"
        },
        new HomeSlide
        {
            Title = "Livraison rapide et suivi",
            Subtitle = "Commandez, payez et suivez vos achats plus facilement.",
            Image = "home.png"
        }
    };

    public ObservableCollection<Product> PromotionProducts { get; } = new();
    public ObservableCollection<Product> RecommendedProducts { get; } = new();

    public MainPage()
    {
        _productService = App.Services.GetRequiredService<IProductService>();
        BindingContext = this;

        _slidesCarousel = CreateSlidesCarousel();
        _slideTimer = Dispatcher.CreateTimer();
        _slideTimer.Interval = TimeSpan.FromSeconds(4);
        _slideTimer.Tick += OnSlideTimerTick;

        Content = BuildContent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (!_slideTimer.IsRunning)
        {
            _slideTimer.Start();
        }

        if (!_hasLoaded)
        {
            _hasLoaded = true;
            _ = LoadHomeDataAsync();
        }
    }

    protected override void OnDisappearing()
    {
        if (_slideTimer.IsRunning)
        {
            _slideTimer.Stop();
        }

        base.OnDisappearing();
    }

    private View BuildContent()
    {
        var root = new VerticalStackLayout
        {
            Padding = 16,
            Spacing = 18
        };

        root.Add(BuildHeroBanner());
        root.Add(BuildSlidesSection());
        root.Add(BuildProductSection("Produits en promotion", PromotionProducts, true));
        root.Add(BuildProductSection("Produits recommandés", RecommendedProducts, false));

        return new ScrollView { Content = root };
    }

    private View BuildHeroBanner()
    {
        var banner = new Frame
        {
            Style = (Style)Application.Current!.Resources["AmazonCard"]
        };

        var grid = new Grid
        {
            ColumnDefinitions =
            {
                new ColumnDefinition(GridLength.Star),
                new ColumnDefinition(GridLength.Auto)
            },
            RowDefinitions =
            {
                new RowDefinition(GridLength.Auto),
                new RowDefinition(GridLength.Auto),
                new RowDefinition(GridLength.Auto)
            },
            ColumnSpacing = 12,
            RowSpacing = 10
        };

        var badge = new Frame
        {
            BackgroundColor = (Color)Application.Current!.Resources["AmazonOrange"],
            Padding = new Thickness(8, 4),
            CornerRadius = 12,
            HasShadow = false,
            HorizontalOptions = LayoutOptions.Start
        };
        badge.Content = new Label
        {
            Text = "MEILLEURES OFFRES",
            FontSize = 12,
            FontAttributes = FontAttributes.Bold,
            TextColor = Colors.White
        };

        var title = new Label
        {
            Text = "Bienvenue sur OrderManagement",
            Style = (Style)Application.Current!.Resources["SectionTitle"]
        };

        var subtitle = new Label
        {
            Text = "Découvrez nos produits, vos promotions du jour et des recommandations pensées pour vous.",
            Style = (Style)Application.Current!.Resources["SectionSubtitle"]
        };

        var actions = new HorizontalStackLayout
        {
            Spacing = 10
        };

        var catalogButton = new Button
        {
            Text = "Voir le catalogue"
        };
        catalogButton.Clicked += OnGoCatalogClicked;

        var cartButton = new Button
        {
            Text = "Mon panier",
            BackgroundColor = (Color)Application.Current!.Resources["AmazonBlue"],
            TextColor = Colors.White
        };
        cartButton.Clicked += OnGoCartClicked;

        actions.Add(catalogButton);
        actions.Add(cartButton);

        var textStack = new VerticalStackLayout
        {
            Spacing = 8
        };
        textStack.Add(badge);
        textStack.Add(title);
        textStack.Add(subtitle);
        textStack.Add(actions);

        var heroImage = new Image
        {
            Source = "home.png",
            HeightRequest = 120,
            WidthRequest = 120,
            Aspect = Aspect.AspectFit,
            HorizontalOptions = LayoutOptions.End,
            VerticalOptions = LayoutOptions.Center
        };

        grid.Add(textStack);
        grid.Add(heroImage);
        Grid.SetColumn(heroImage, 1);
        Grid.SetRowSpan(textStack, 3);
        Grid.SetRow(heroImage, 0);

        banner.Content = grid;
        return banner;
    }

    private View BuildSlidesSection()
    {
        var layout = new VerticalStackLayout
        {
            Spacing = 10
        };

        layout.Add(new Label
        {
            Text = "Offres du moment",
            Style = (Style)Application.Current!.Resources["SectionTitle"]
        });

        _slidesCarousel.HeightRequest = 210;
        layout.Add(_slidesCarousel);

        var indicators = new IndicatorView
        {
            HorizontalOptions = LayoutOptions.Center,
            IndicatorColor = (Color)Application.Current!.Resources["AmazonBorder"],
            SelectedIndicatorColor = (Color)Application.Current!.Resources["AmazonOrange"],
            Margin = new Thickness(0, 4, 0, 0)
        };
        indicators.SetBinding(IndicatorView.ItemsSourceProperty, new Binding(nameof(Slides), source: this));
        _slidesCarousel.IndicatorView = indicators;
        layout.Add(indicators);

        return layout;
    }

    private CarouselView CreateSlidesCarousel()
    {
        var carousel = new CarouselView
        {
            ItemsSource = Slides,
            IsSwipeEnabled = true,
            ItemTemplate = new DataTemplate(() =>
            {
                var frame = new Frame
                {
                    Style = (Style)Application.Current!.Resources["AmazonCard"]
                };

                var grid = new Grid
                {
                    ColumnDefinitions =
                    {
                        new ColumnDefinition(new GridLength(2, GridUnitType.Star)),
                        new ColumnDefinition(GridLength.Star)
                    }
                };

                var title = new Label
                {
                    FontSize = 22,
                    FontAttributes = FontAttributes.Bold,
                    TextColor = (Color)Application.Current!.Resources["AmazonDark"]
                };
                title.SetBinding(Label.TextProperty, nameof(HomeSlide.Title));

                var subtitle = new Label
                {
                    Style = (Style)Application.Current!.Resources["SectionSubtitle"]
                };
                subtitle.SetBinding(Label.TextProperty, nameof(HomeSlide.Subtitle));

                var button = new Button
                {
                    Text = "Découvrir",
                    BackgroundColor = (Color)Application.Current!.Resources["AmazonOrange"],
                    TextColor = Colors.White,
                    HorizontalOptions = LayoutOptions.Start
                };

                var left = new VerticalStackLayout
                {
                    Spacing = 6
                };
                left.Add(title);
                left.Add(subtitle);
                left.Add(button);

                var image = new Image
                {
                    Aspect = Aspect.AspectFit,
                    HorizontalOptions = LayoutOptions.End,
                    VerticalOptions = LayoutOptions.Center,
                    HeightRequest = 100,
                    WidthRequest = 100
                };
                image.SetBinding(Image.SourceProperty, nameof(HomeSlide.Image));

                grid.Add(left);
                grid.Add(image);
                Grid.SetColumn(image, 1);

                frame.Content = grid;
                return frame;
            })
        };

        return carousel;
    }

    private View BuildProductSection(string titleText, ObservableCollection<Product> products, bool isPromotion)
    {
        var layout = new VerticalStackLayout
        {
            Spacing = 10
        };

        layout.Add(new Label
        {
            Text = titleText,
            Style = (Style)Application.Current!.Resources["SectionTitle"]
        });

        var collection = new CollectionView
        {
            ItemsSource = products,
            ItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Horizontal) { ItemSpacing = 12 },
            HorizontalScrollBarVisibility = ScrollBarVisibility.Never,
            ItemTemplate = new DataTemplate(() => CreateProductCard(isPromotion))
        };

        layout.Add(collection);
        return layout;
    }

    private View CreateProductCard(bool isPromotion)
    {
        var frame = new Frame
        {
            Style = (Style)Application.Current!.Resources["AmazonCard"],
            WidthRequest = 180,
            Margin = new Thickness(0, 0, 12, 0)
        };

        var stack = new VerticalStackLayout
        {
            Spacing = 6
        };

        var badge = new Frame
        {
            BackgroundColor = isPromotion
                ? (Color)Application.Current!.Resources["AmazonOrange"]
                : (Color)Application.Current!.Resources["AmazonBlue"],
            Padding = new Thickness(8, 4),
            CornerRadius = 12,
            HasShadow = false,
            HorizontalOptions = LayoutOptions.Start
        };
        badge.Content = new Label
        {
            Text = isPromotion ? "PROMO" : "RECOMMANDÉ",
            FontSize = 11,
            FontAttributes = FontAttributes.Bold,
            TextColor = Colors.White
        };

        var image = new Image
        {
            Source = isPromotion ? "home.png" : "dotnet_bot.png",
            HeightRequest = 80,
            Aspect = Aspect.AspectFit
        };

        var name = new Label
        {
            FontAttributes = FontAttributes.Bold,
            LineBreakMode = LineBreakMode.TailTruncation
        };
        name.SetBinding(Label.TextProperty, nameof(Product.Name));

        var description = new Label
        {
            Style = (Style)Application.Current!.Resources["SectionSubtitle"],
            LineBreakMode = LineBreakMode.TailTruncation
        };
        description.SetBinding(Label.TextProperty, nameof(Product.Description));

        var price = new Label
        {
            FontAttributes = FontAttributes.Bold,
            TextColor = isPromotion
                ? (Color)Application.Current!.Resources["AmazonOrange"]
                : (Color)Application.Current!.Resources["AmazonBlue"]
        };
        price.SetBinding(Label.TextProperty, new Binding(nameof(Product.Price), stringFormat: isPromotion ? "Prix promo: {0} MAD" : "Prix: {0} MAD"));

        stack.Add(badge);
        stack.Add(image);
        stack.Add(name);
        stack.Add(description);
        stack.Add(price);

        frame.Content = stack;
        return frame;
    }

    private async Task LoadHomeDataAsync()
    {
        var products = (await _productService.GetProductsAsync()).ToList();

        PromotionProducts.Clear();
        RecommendedProducts.Clear();

        foreach (var product in products.Take(4))
        {
            PromotionProducts.Add(product);
        }

        foreach (var product in products.Skip(4).Take(4))
        {
            RecommendedProducts.Add(product);
        }

        if (PromotionProducts.Count == 0)
        {
            PromotionProducts.Add(new Product
            {
                Cle = 1,
                Name = "Produit promo",
                Description = "Exemple de produit en promotion.",
                Price = 99
            });
        }

        if (RecommendedProducts.Count == 0)
        {
            RecommendedProducts.Add(new Product
            {
                Cle = 2,
                Name = "Produit recommandé",
                Description = "Exemple de produit recommandé.",
                Price = 149
            });
        }
    }

    private async void OnGoCatalogClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//produits");
    }

    private async void OnGoCartClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("panier");
    }

    private void OnSlideTimerTick(object? sender, EventArgs e)
    {
        if (Slides.Count == 0)
        {
            return;
        }

        var nextPosition = _slidesCarousel.Position + 1;
        if (nextPosition >= Slides.Count)
        {
            nextPosition = 0;
        }

        _slidesCarousel.Position = nextPosition;
    }
}
