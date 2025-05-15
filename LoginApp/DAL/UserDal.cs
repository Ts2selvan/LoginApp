using LoginApp.DAL.Interface;
using LoginApp.DTO;
using Microsoft.Data.SqlClient;
using System.Data;

namespace LoginApp.DAL
{
    public class UserDal:IUserDal
    {
        private readonly IConfiguration _config;
        public UserDal(IConfiguration config)
        {
            _config = config;
        }
        public UserProfileDto GetUserProfileById(int userId)
        {

            var dto = new UserProfileDto();
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("DBConnection")))
            {
                SqlCommand cmd = new SqlCommand("pr_GetUserProfileById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", userId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    dto.UserId = Convert.ToInt32(reader["UserId"]);
                    dto.Name = reader["Name"].ToString();
                    dto.Email = reader["Email"].ToString();
                    dto.City = reader["City"].ToString();
                    dto.Contact = reader["Contact"].ToString();
                }
            }
            return dto;
        }
    }
}
