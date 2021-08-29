using Wyvern.Objects;
namespace Wyvern.Database
{
    public class WyvernDatabase
    {
        WyvernDatabaseOptions options;
        public WyvernDatabase(WyvernDatabaseOptions options)
        {
            this.options = options;
            switch (options.databaseType)
            {
                case DatabaseType.MongoDB:
                    InitializeMongoDB();
                    break;
                default:
                    throw new DatabaseError("Database type not implemented: " + options.databaseType);
            }
        }
        private ISuccess InitializeMongoDB()
        {
            return new Success(true, null);
        }
    }
    public class WyvernDatabaseOptions
    {
        public DatabaseType databaseType;
        public CacheType cacheType;
        public IConnectionSettings connectionSettings;
        public WyvernDatabaseOptions(DatabaseType databaseType, CacheType cacheType, IConnectionSettings connectionSettings)
        {
            this.databaseType = databaseType;
            this.cacheType = cacheType;
            this.connectionSettings = connectionSettings;
        }
    }
    public enum DatabaseType
    {
        Sqlite,
        Postgres,
        MySql,
        MongoDB
    }
    public enum CacheType
    {
        Redis,
        Memory
    }
}