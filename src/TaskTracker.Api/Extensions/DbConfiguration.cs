using Microsoft.EntityFrameworkCore;
using SimpleChat.Infrastructure.Data;

namespace TaskTracker.Api.Extensions
{
    public static class DbConfiguration
    {
        public static void Configuration(
            IConfiguration configuration,
            IServiceCollection services)
        {
            services.AddDbContext<CastomTaskTrackerDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("TaskTrackerDbConnection")));
        }
    }
}