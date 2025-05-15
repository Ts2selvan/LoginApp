using LoginApp.Models;
using LoginApp.Repository.Interface;
using LoginApp.Service.Interface;

namespace LoginApp.Service
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public bool IsEmailTaken(string email) => _repo.EmailExists(email);

        public void RegisterUser(User user)
        {
            user.CreatedDate = DateTime.Now;
            _repo.AddUser(user);
        }

        public User Authenticate(string email, string password) =>
            _repo.GetUserByEmailAndPassword(email, password);

        public User GetUser(int userId) => _repo.GetUserById(userId);
    }
}
