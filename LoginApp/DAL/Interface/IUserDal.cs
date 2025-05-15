using LoginApp.DTO;

namespace LoginApp.DAL.Interface
{
    public interface IUserDal
    {
        UserProfileDto GetUserProfileById(int userId);
    }
}
