namespace Car.ShopMAUI.Views;

using Mapsui.Tiling;
using Mapsui.UI.Maui;
using Microsoft.Maui.Devices.Sensors;
using System.Linq.Expressions;
using Map = Mapsui.Map;

public class MapCars : ContentPage
{
    // creamos el mapa
    Map map = new();

    MapView view = new();
    public MapCars()
    {
        map.Layers.Add(OpenStreetMap.CreateTileLayer());
        view.IsNorthingButtonVisible = true;
        view.IsEnabled = true;

        view.PinClicked += (sender, args) => DisplayAlert("", $"{args.Point.Latitude}  {args.Point.Longitude}", "Ok");

        view.Map = map;

        Content = view;

    }

    protected override async void OnAppearing()
    {
        Location location = await Geolocation.Default.GetLocationAsync();

        var pin = new Pin(view)
        {
            Type = PinType.Pin,
            Label = "Un carro",
            Position = new Position(location.Latitude, location.Longitude)
        };

        view.Pins.Add(pin);

        base.OnAppearing();
    }
}