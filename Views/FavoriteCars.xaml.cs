using Car.ShopMAUI.Context;
using Car.ShopMAUI.Models;

namespace Car.ShopMAUI.Views;

public partial class FavoriteCars : ContentPage
{
    public FavoriteCars()
    {
        InitializeComponent();
    }

    private async Task LoadData()
    {
        CarsList.ItemsSource = null;
        CarsList.ItemsSource = await new DataContext().GetFavorites();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadData();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var carId = ((Cars)((ImageButton)sender).BindingContext).Id;


        var result = await new DataContext().RemoveFromFavorites(carId);

        await DisplayAlert("Auto favorito", result ? "El vehiculo se removio exitosamente" : 
                                                    "Hubo un problema tratando de elimiar el producto, intentalo de nuevo", "Ok");

        await LoadData();

    }
}