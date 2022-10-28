namespace Car.ShopMAUI.Views;

using Car.ShopMAUI.Context;
using Mapsui.Tiling;
using Mapsui.UI.Maui;

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
        view.MyLocationFollow = true;
        view.MyLocationEnabled = true;
        view.IsMyLocationButtonVisible = true;
        view.PinClicked += (sender, args) => DisplayAlert("", $"{args.Pin.Label} ", "Ok");

        view.Map = map;

        Content = view;

        Title = "Mapa";

    }

    protected override async void OnAppearing()
    {
        RestService dataContext = new();

        //Location location = await Geolocation.Default.GetLocationAsync();

        var cars = dataContext.GetCars().Where(x => x.Lat is not null && x.Lon is not null).ToList();

        foreach (var car in cars)
        {
            var pin = new Pin(view)
            {
                Type = PinType.Pin,
                Label = $"{car.Description}  {car.Price.ToString("C2")}",
                Position = new Position((double)car.Lat, (double)car.Lon),
                
            };

            view.Pins.Add(pin);
        }
        base.OnAppearing();
    }
}