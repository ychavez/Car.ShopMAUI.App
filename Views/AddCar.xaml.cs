using Car.ShopMAUI.Context;
using Car.ShopMAUI.Models;

namespace Car.ShopMAUI.Views;

public partial class AddCar : ContentPage
{
    public AddCar()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var car = new Cars
        {
            Brand = txtMarca.Text,
            Description = txtDescripcion.Text,
            Model = txtModelo.Text,
            Year = int.Parse(txtAnio.Text),
            Price = decimal.Parse(txtPrecio.Text),
            PhotoUrl = "https://cdn1.coppel.com/images/catalog/pr/7278682-1.jpg"
        };

        new RestService().SetCar(car);
        await DisplayAlert("Agregado", "El auto se agrego correctamente", "OK");
        await Navigation.PopAsync();

        MessagingCenter.Send<Page>(this, "UpdateList");


    }

    private async void btnPhoto_Clicked(object sender, EventArgs e)
    {

        if (MediaPicker.Default.IsCaptureSupported)
        {

            FileResult photo = await MediaPicker.Default.CapturePhotoAsync();


            imgCar.Source = ImageSource.FromStream(async x => await photo.OpenReadAsync());


        }

    }
}