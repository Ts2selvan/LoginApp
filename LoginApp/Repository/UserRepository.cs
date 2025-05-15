using LoginApp.Data;
using LoginApp.Models;
using LoginApp.Repository.Interface;

namespace LoginApp.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly loginDbContext _context;

        public UserRepository(loginDbContext context)
        {
            _context = context;
        }

        public User GetUserByEmail(string email) =>
            _context.Users.FirstOrDefault(u => u.Email == email);

        public User GetUserByEmailAndPassword(string email, string password) =>
            _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public bool EmailExists(string email) =>
            _context.Users.Any(u => u.Email == email);

        public User GetUserById(int userId) =>
            _context.Users.Find(userId);
    }
}
