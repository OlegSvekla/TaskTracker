using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimpleChat.Infrastructure.Data;
using TaskTracker.Domain.Entities;

namespace TaskTracker.Infrastructure.Data
{
    public class CastomTaskTrackerDbContextSeed
    {
        public static async Task SeedAsyncData(CastomTaskTrackerDbContext dbContext, ILogger logger, int retry = 0)
        {
            var retryForAvailability = retry;

            try
            {
                logger.LogInformation("Data seeding started.");

                if (!await dbContext.CastomTasks.AnyAsync())
                {
                    await dbContext.CastomTasks.AddRangeAsync(GetPreConfiguredCastomTasks());
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability >= 10) throw;
                {
                    retryForAvailability++;

                    logger.LogError(ex.Message);
                    await SeedAsyncData(dbContext, logger, retryForAvailability);
                }
                throw;
            }
        }

        private static IEnumerable<CastomTask> GetPreConfiguredCastomTasks()
        {
            return new List<CastomTask>
            {
                new CastomTask 
                { 
                    Title = "Task 1", 
                    Description = "Description for Task 1", 
                    CreationDate = DateTime.Now, 
                    UpdateDate = DateTime.Now 
                },

                new CastomTask 
                { 
                    Title = "Task 2", 
                    Description = "Description for Task 2", 
                    CreationDate = DateTime.Now, 
                    UpdateDate = DateTime.Now 
                },

                new CastomTask 
                { 
                    Title = "Task 3", 
                    Description = "Description for Task 3", 
                    CreationDate = DateTime.Now, 
                    UpdateDate = DateTime.Now 
                },

                new CastomTask 
                { 
                    Title = "Task 4", 
                    Description = "Description for Task 4", 
                    CreationDate = DateTime.Now, 
                    UpdateDate = DateTime.Now                
                },

                new CastomTask 
                { 
                    Title = "Task 5", 
                    Description = "Description for Task 5", 
                    CreationDate = DateTime.Now, 
                    UpdateDate = DateTime.Now                 
                },

                new CastomTask 
                { 
                    Title = "Task 6",
                    Description = "Description for Task 6",
                    CreationDate = DateTime.Now, 
                    UpdateDate = DateTime.Now 
                },

                new CastomTask 
                { 
                    Title = "Task 7",
                    Description = "Description for Task 7",
                    CreationDate = DateTime.Now, 
                    UpdateDate = DateTime.Now 
                },

                new CastomTask
                { 
                    Title = "Task 8", 
                    Description = "Description for Task 8", 
                    CreationDate = DateTime.Now, 
                    UpdateDate = DateTime.Now 
                },

                new CastomTask 
                {
                    Title = "Task 9",
                    Description = "Description for Task 9",
                    CreationDate = DateTime.Now,
                    UpdateDate = DateTime.Now 
                },

                new CastomTask 
                {
                    Title = "Task 10", 
                    Description = "Description for Task 10",
                    CreationDate = DateTime.Now, 
                    UpdateDate = DateTime.Now 
                }
            };
        }
    }
}