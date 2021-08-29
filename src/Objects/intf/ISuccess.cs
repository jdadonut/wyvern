
namespace Wyvern.Objects
{
    public interface ISuccess
    {
        bool State { get; }
        object? Data { get; }
    }
}