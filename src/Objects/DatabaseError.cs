using System;
namespace Wyvern.Objects
{
    public class DatabaseError : Exception
    {
        public DatabaseError(string message) : base(message)
        {
        }
    }
}