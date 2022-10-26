namespace Car.ShopMAUI.Context
{
    public static class CarShopConstants
    {
        public const string DatabaseFileName = "CarShop.db3";

        public const SQLite.SQLiteOpenFlags Flags
            = SQLite.SQLiteOpenFlags.ReadWrite |
            // crea la base de datos en caso de que no exista  
            SQLite.SQLiteOpenFlags.Create |
            // habilita el uso de mulihilos a la base de datos
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath => Path.Combine(FileSystem.AppDataDirectory, DatabaseFileName);
    }
}
