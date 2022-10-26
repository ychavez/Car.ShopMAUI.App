using Car.ShopMAUI.Views;

namespace Car.ShopMAUI
{
    public class MainTabbedPage : TabbedPage
    {
        // definir los tabs que tendra mi aplicacion
        public MainTabbedPage()
        {
            Children.Add(new CarsForSale());
     
        }

    }
}
