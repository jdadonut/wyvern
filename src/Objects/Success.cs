
namespace Wyvern.Objects
{
    public class Success : ISuccess
    {
        public bool State { get; internal set; }
        public object? Data { get; internal set; }
        public Success (bool state, object? data)
        {
            State = state;
            Data = data;
        }

    }
}