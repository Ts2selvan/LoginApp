using LoginApp.Models;

namespace LoginApp.Service.Interface
{
    public interface IUserService
    {
        bool IsEmailTaken(string email);
        void RegisterUser(User user);
        User Authenticate(string email, string password);
        User GetUser(int userId);
    }
}
