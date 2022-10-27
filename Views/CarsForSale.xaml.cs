using Car.ShopMAUI.Context;
using Car.ShopMAUI.Models;

namespace Car.ShopMAUI.Views;

public partial class CarsForSale : ContentPage
{


    public CarsForSale()
    {
        InitializeComponent();
        LoadList();
        MessagingCenter.Subscribe<Page>(this, "UpdateList", messageCallBack);
    }


    private void messageCallBack(object obj)
        => LoadList();

    private void LoadList()
            => CarsList.ItemsSource = new RestService().GetCars();

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddCar());
    }

    private  void srchVehiculo_TextChanged(object sender, TextChangedEventArgs e)
    {
        string searchText = srchVehiculo.Text.ToUpper();

        var carSearched = new RestService().GetCars().Where(x => (x.Model?.ToUpper().Contains(searchText) ?? false) ||
                                                                    (x.Description?.ToUpper().Contains(searchText) ?? false)
                                                                    || (x.Brand?.ToUpper().Contains(searchText) ?? false));

        CarsList.ItemsSource = carSearched;

    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var favoriteResult = await new DataContext().SetAsFavorite((Cars)((ImageButton)sender).BindingContext);

        await DisplayAlert("Auto favorito", favoriteResult ? "Auto agregado a favoritos" : "El auto ya esta en favoritos", "Ok");
    }
}