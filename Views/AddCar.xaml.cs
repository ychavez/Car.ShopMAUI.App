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
        await NewCar();

    }

    private async Task NewCar()
    {
        Location location = await Geolocation.Default.GetLocationAsync();

        var car = new Cars
        {
            Brand = txtMarca.Text,
            Description = txtDescripcion.Text,
            Model = txtModelo.Text,
            Year = int.Parse(txtAnio.Text),
            Price = decimal.Parse(txtPrecio.Text),
            PhotoUrl = "https://cdn1.coppel.com/images/catalog/pr/7278682-1.jpg",
            Lat = location.Latitude,
            Lon = location.Longitude

        };




        new RestService().SetCar(car);
        /// await DisplayAlert("Agregado", "El auto se agrego correctamente", "OK");
        await TextToSpeech.SpeakAsync($"{car.Brand}, {car.Model}, agregado correctamente!");

        //  await Flashlight.Default.TurnOnAsync();
        //Vibration.Default.Vibrate(10)


        await Navigation.PopAsync();

        MessagingCenter.Send<Page>(this, "UpdateList");
    }

    private async void btnPhoto_Clicked(object sender, EventArgs e)
    {

        if (MediaPicker.Default.IsCaptureSupported)
        {

            //  bool answer = await DisplayAlert("Pregunta", "Esto es una pregunta?", "Si", "No");
            // accion de si o no dependiento de ok o cancelar


            string action = await DisplayActionSheet("Cual deberia tomar", "Cancelar", "Ok", "Foto", "Tomar de la galeria");
            /// este nos deja seleccionar de una lista de acciones y nos trgresa un string


            // string name = await DisplayPromptAsync("Titulo", "Escribe tu nombre");
            // nos regresa lo capturado por el usuario


            FileResult photo;
            if (action == "Foto")

                photo = await MediaPicker.Default.CapturePhotoAsync();
            else
                photo = await MediaPicker.Default.PickPhotoAsync();


            imgCar.Source = ImageSource.FromStream(async x => await photo.OpenReadAsync());


        }

    }
}