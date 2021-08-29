using System;
using System.Collections.Generic;
using Wyvern.Objects;
namespace Wyvern.Database
{
    class MongoConnectionSettings : IConnectionSettings
    {
        public string ConnectionString { get {
            return $"mongodb://{Username}:{Password}@{ClusterUri}/{Database}?retryWrites={retryWrites}";
        }}
        public string Username { get; set; }
        public string Password { get; set; }
        public string ClusterUri { get; set; }
        public string Database { get; set; }
        public bool retryWrites { get; set; }

        public MongoConnectionSettings(string username, string password, string clusterUri, string database, bool retryWrites)
        {
            Username = username;
            Password = password;
            ClusterUri = clusterUri;
            Database = database;
            this.retryWrites = retryWrites;
        }
        public static MongoConnectionSettings From(object settings)
        {
            var settingsDict = settings as IDictionary<string, object>;
            if (settingsDict == null)
                throw new ArgumentException("Settings must be a dictionary");
            
            var username = settingsDict["username"] as string;
            var password = settingsDict["password"] as string;
            var clusterUri = settingsDict["clusterUri"] as string;
            var database = settingsDict["database"] as string;
            var retryWrites = settingsDict["retryWrites"] as bool?;

            return new MongoConnectionSettings(username, password, clusterUri, database, retryWrites ?? false);
        }
    }
}