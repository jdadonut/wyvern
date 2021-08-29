
namespace Wyvern.Objects
{
    public interface IUser
    {
        string Username { get; set; }
        string PasswordHash { get; set; }
        string Email { get; set; }
        string Phone { get; set; }
        A11yLanguage PreferredLanguage { get; set; }
        string Avatar { get; set; }
        IUserStatus Status { get; set; }
        string Created { get; set; }
    }
    public interface IUserStatus
    {
        string Status { get; set; }
        IEmoji Emoji { get; set; }
        IUserState State { get; set; }

    }
    
}