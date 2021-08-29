using Wyvern.Objects;
using Snowflake = System.Decimal;
namespace Wyvern.Database.Providers
{
    public interface IWyvernDatabaseProvider
    {
        void Initialize();
        void Destroy();
        void Connect();
        void Disconnect();
        IUser GetUser(Snowflake id);
        IUser GetUser(string username);
        IGuild GetGuild(Snowflake id);
        IChannel GetChannel(IGuild guild, Snowflake id);
}