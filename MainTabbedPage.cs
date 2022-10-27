using Car.ShopMAUI.Views;
using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;

namespace Car.ShopMAUI
{
    public class MainTabbedPage : Microsoft.Maui.Controls.TabbedPage
    {
        // definir los tabs que tendra mi aplicacion
        public MainTabbedPage()
        {
            Children.Add(new CarsForSale());
            Children.Add(new FavoriteCars());
            Children.Add(new MapCars());

            On<Microsoft.Maui.Controls.PlatformConfiguration.Android>().SetIsSwipePagingEnabled(false);
        }

    }
}
