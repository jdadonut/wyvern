using System;
using System.IO;
using Json = System.Text.Json.JsonSerializer;
using Wyvern.Database;
namespace Wyvern
{
    class Program
    {
        static Config config = Json.Deserialize<Config>(File.ReadAllText("config.json"));
        static void Main(string[] args)
        {
            Wyvern wyvern = new Wyvern().WithDatabase(new WyvernDatabase(
                new WyvernDatabaseOptions(
                    DatabaseType.MongoDB,
                    CacheType.Memory,
                    new MongoConnectionSettings(
                        config.Mongo.Username,
                        config.Mongo.Password,
                        config.Mongo.ClusterUri,
                        config.Mongo.Database,
                        config.Mongo.retryWrites
                    )
                )
            ));
            wyvern.Start(config.Logging.LogLevel);
        }


    }
}
