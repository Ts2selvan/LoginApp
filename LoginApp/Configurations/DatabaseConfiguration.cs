using System.Runtime.CompilerServices;
using LoginApp.Data;
using Microsoft.EntityFrameworkCore;

namespace LoginApp.Configurations
{
    public static class DatabaseConfiguration
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<loginDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DBConnection")));
        }
    }
}
