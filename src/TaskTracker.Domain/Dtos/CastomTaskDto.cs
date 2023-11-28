using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.Domain.Dtos
{
    public class CastomTaskDto : BaseEntityDto
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}