using SQLite;

namespace Car.ShopMAUI.Models
{
    public class Cars
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public string PhotoUrl { get; set; }

        public double? Lat { get; set; }
        public double? Lon { get; set; }
    }
}
