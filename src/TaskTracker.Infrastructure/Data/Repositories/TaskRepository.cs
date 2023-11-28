using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Domain.Interfaces.IRepositories;

namespace TaskTracker.Infrastructure.Data.Repositories
{
    public class TaskRepository : BaseRepository<Task>, ITaskRepository
    {
        public TaskRepository(SimpleChatDbContext dbContext) : base(dbContext)
        {
        }
    }
}
