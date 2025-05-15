using LoginApp.Models;

namespace LoginApp.Repository.Interface
{
    public interface IUserRepository
    {
        User GetUserByEmail(string email);
        User GetUserByEmailAndPassword(string email, string password);
        void AddUser(User user);
        bool EmailExists(string email);
        User GetUserById(int userId);

    }
}
