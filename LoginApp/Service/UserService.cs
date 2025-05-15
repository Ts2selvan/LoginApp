using LoginApp.DAL.Interface;
using LoginApp.DTO;
using LoginApp.Models;
using LoginApp.Repository.Interface;
using LoginApp.Service.Interface;

namespace LoginApp.Service
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _repo;
        private readonly IUserDal _dal;

        public UserService(IUserRepository repo, IUserDal dal)
        {
            _repo = repo;
            _dal = dal;
        }
        public UserProfileDto GetUserProfile(int userId)
        {
            return _dal.GetUserProfileById(userId);
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
