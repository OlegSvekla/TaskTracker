namespace TaskTracker.Api.Extensions
{
    public static class DbConfiguration
    {
        public static void Configuration(
            IConfiguration configuration,
            IServiceCollection services)
        {
            services.AddDbContext<TaskTrackerDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("TaskTrackerDbConnection")));
        }
    }
}
