# OrderManagement.Mobile

Application mobile **.NET MAUI** de gestion de commandes, connectée à un backend ASP.NET Core exposant une API REST.

## Objectif du projet

Le projet a été construit progressivement pour :
- se connecter au backend local `https://localhost:7124/`
- afficher les catégories et produits depuis l’API
- proposer un panier persistant
- créer des pages de commande et de paiement
- appliquer un style e-commerce inspiré d’Amazon
- fournir un exemple pédagogique de Binding en .NET MAUI

## Étapes d’implémentation du projet

### 1. Création de la base MAUI
- Configuration du projet `OrderManagement.Mobile`
- Activation de `UseMaui`, `ImplicitUsings` et `Nullable`
- Mise en place des ressources globales dans `Resources/Styles`

### 2. Connexion au backend
- Ajout d’un `HttpClient` dans `MauiProgram.cs`
- Configuration de l’URL de base pour le développement :
  - Android : `https://10.0.2.2:7124/`
  - autres plateformes : `https://localhost:7124/`
- Création des services HTTP pour consommer l’API

### 3. Récupération des catégories
- Lecture du contrat depuis `swagger.json`
- Création du modèle `Category`
- Création de `ICategoryService` et `CategoryService`
- Affichage des catégories dans `CategoryPage`
- Ajout d’un menu latéral dynamique dans `AppShell`

### 4. Récupération des produits
- Création du modèle `Product`
- Création de `IProductService` et `ProductService`
- Affichage des produits dans `ProductPage`
- Chargement des données depuis l’API au démarrage

### 5. Gestion du panier
- Création du modèle `CartItem`
- Création de `ICartService` et `CartService`
- Sauvegarde locale avec `Preferences`
- Ajout, suppression, modification de quantité
- Affichage de la page `CartPage`

### 6. Commande et paiement
- Création des modèles `OrderDto` et `PayementDto`
- Création de `IOrderService` / `OrderService`
- Création de `IPayementService` / `PayementService`
- Ajout des pages `OrderPage` et `PaymentPage`
- Liaison avec les endpoints du backend quand ils sont disponibles

### 7. Refonte visuelle
- Application d’un thème bleu/orange inspiré d’Amazon
- Centralisation des couleurs dans `Colors.xaml`
- Styles partagés dans `Styles.xaml`
- Modernisation des pages principales avec des cartes, boutons et sections visuelles

### 8. Refonte de la page d’accueil
- Transformation de `MainPage` en vitrine e-commerce
- Ajout d’un carrousel de slides
- Ajout des sections :
  - produits en promotion
  - produits recommandés
- Ajout d’un défilement automatique du carrousel

### 9. Exemple pédagogique de Binding
- Création de `BindingExamplePage.xaml`
- Création de `BindingExampleViewModel.cs`
- Utilisation de `BindingContext`
- Utilisation de `INotifyPropertyChanged`
- Exemple avec `Entry`, `Label` et `Button` liés par Binding

## Structure principale

- `MainPage.xaml` / `MainPage.xaml.cs` : accueil e-commerce
- `Views/CategoryPage.*` : catégories depuis l’API
- `Views/ProductPage.*` : produits depuis l’API
- `Views/CartPage.*` : panier local
- `Views/OrderPage.*` : commande
- `Views/PaymentPage.*` : paiement
- `Views/BindingExamplePage.*` : exemple Binding
- `ViewModels/BindingExampleViewModel.cs` : ViewModel pédagogique
- `Services/` : accès aux APIs et logique métier
- `Resources/Styles/` : couleurs et styles globaux

## Explication rapide du Binding

- **Binding** : permet de relier une propriété XAML à une propriété C#.
- **BindingContext** : objet source des bindings de la page.
- **Mode=TwoWay** : la donnée se synchronise dans les deux sens entre l’interface et le ViewModel.
- **INotifyPropertyChanged** : notifie l’interface quand une propriété change.
- **Command** : remplace souvent `Clicked` en MVVM pour séparer la logique métier de la vue.

## Lancer l’application

1. Ouvrir la solution `OrderManagement.Mobile.slnx` dans Visual Studio
2. Vérifier que le backend est démarré sur `https://localhost:7124/`
3. Lancer la cible souhaitée : Android, Windows, iOS ou MacCatalyst

## Remarques

- Le backend local doit être accessible depuis l’émulateur ou l’appareil de test.
- Sur Android émulateur, utiliser l’adresse `https://10.0.2.2:7124/` pour atteindre `localhost` du poste de développement.
- Les sections promotion et recommandations sont dérivées du catalogue produit existant.

## Auteur

Projet d’exemple MAUI pour la gestion de commandes et l’apprentissage du Binding MVVM.
