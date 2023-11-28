using SimpleChat.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Domain.Entities;
using TaskTracker.Domain.Interfaces.IRepositories;

namespace TaskTracker.Infrastructure.Data.Repositories
{
    public class CastomTaskRepository : BaseRepository<CastomTask>, ICastomTaskRepository
    {
        public CastomTaskRepository(CastomTaskTrackerDbContext dbContext) : base(dbContext)
        {
        }
    }
}
