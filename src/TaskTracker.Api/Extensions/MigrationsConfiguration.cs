using Microsoft.EntityFrameworkCore;
using SimpleChat.Infrastructure.Data;
using TaskTracker.Infrastructure.Data;

namespace TaskTracker.Api.Extensions
{
    public static class MigrationsConfiguration
    {
        public static async Task<IApplicationBuilder> RunDbContextMigrations(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var logger = serviceProvider.GetRequiredService<ILogger<CastomTaskTrackerDbContextSeed>>();

                logger.LogInformation("Database migration running...");

                try
                {
                    var context = serviceProvider.GetRequiredService<CastomTaskTrackerDbContext>();
                    context.Database.Migrate();

                    await CastomTaskTrackerDbContextSeed.SeedAsyncData(context, logger);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }
            return app;
        }
    }
}