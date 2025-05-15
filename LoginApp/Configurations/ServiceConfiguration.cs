using LoginApp.Repository;
using LoginApp.Repository.Interface;
using LoginApp.Service;
using LoginApp.Service.Interface;

namespace LoginApp.Configurations
{
    public static class ServiceConfiguration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

        }
    }
}
