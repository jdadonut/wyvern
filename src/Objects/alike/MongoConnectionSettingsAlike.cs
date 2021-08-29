
namespace Wyvern.Objects
{
    public class MongoConnectionSettingsAlike
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ClusterUri { get; set; }
        public string Database { get; set; }
        public bool retryWrites { get; set; }
    }
}