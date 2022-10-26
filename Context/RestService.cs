using Car.ShopMAUI.Models;
using System.Text;
using System.Text.Json;

namespace Car.ShopMAUI.Context
{
    public class RestService
    { /*
       * quiero que esta clase pueda ser capaz de obtener informacion de servicios Rest y poderlos
       * regresar como objetos*/
        HttpClient _httpClient;
        Uri _UrlBase;

        //https://carshopwebapi.azurewebsites.net/api/carsForSalesApi


        public RestService()
        {
            // configuramos el Urlbase
            _UrlBase = new Uri("https://carshopwebapi.azurewebsites.net");
            _httpClient = new();
            _httpClient.BaseAddress = _UrlBase;
        }

        public List<Cars> GetCars() 
        {
            var respone = _httpClient.GetAsync("/api/carsForSalesApi").Result;
            if (respone.IsSuccessStatusCode)
            {
                string content = respone.Content.ReadAsStringAsync().Result;

                /// en esta linea estamos transformando el string(JSON) a objeto
                return JsonSerializer.Deserialize<List<Cars>>(content, 
                    new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }

            throw new Exception("Error al tratar de obtener la informacion");
        }

        public void SetCar(Cars car) 
        {
            // transformamos el objeto en un JSON de string
            var json = JsonSerializer.Serialize(car);

            // vamos a agregar el encoding a nuestro JSON
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            // mandamos el json al servicio web
            var response = _httpClient.PostAsync("/api/carsForSalesApi", data).Result;


            // validamos que la peticion sea correcta
            if (!response.IsSuccessStatusCode)
                throw new Exception("Error al tratar de enviar la informacion al servicio web");
        
        }
    }
}
