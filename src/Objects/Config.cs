using Wyvern.Objects;
namespace Wyvern
{
    public class Config
    {
        public MongoConnectionSettingsAlike Mongo { get; set; }
        public LoggingConfig Logging { get; set; }
    }
}