using Car.ShopMAUI.Models;
using SQLite;

namespace Car.ShopMAUI.Context
{
    public class DataContext
    {
        SQLiteAsyncConnection Database;

        async Task Init() 
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(CarShopConstants.DatabasePath, CarShopConstants.Flags);
            
            var result = await Database.CreateTableAsync<Cars>();
        
        }

        public async Task<List<Cars>> GetFavorites() 
        {
            await Init();
            return await Database.Table<Cars>().ToListAsync();
        }


        public async Task<Cars> GetCarById(int id) 
        {

            await Init();
            return await Database.Table<Cars>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task SetAsFavorite(Cars car) 
        {

            await Init();
            var _car = await GetCarById(car.Id);

            if (_car is not null)
                return;

             await Database.InsertAsync(car);

        }


    }
}
