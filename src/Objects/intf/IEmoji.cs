
namespace Wyvern.Objects
{
    public interface IEmoji
    {
        string Source { get; private set;}
        ulong id { get; internal set;}
        string Name { get; set;}
        ulong ServerId { get; internal set;}
        


}