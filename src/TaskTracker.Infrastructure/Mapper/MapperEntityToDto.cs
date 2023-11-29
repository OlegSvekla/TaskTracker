using TaskTracker.Domain.Dtos;
using TaskTracker.Domain.Entities;

namespace TaskTracker.Infrastructure.Mapper
{
    public sealed class MapperEntityToDto : AutoMapper.Profile
    {
        public MapperEntityToDto()
        {
            CreateMap<CastomTask, CastomTaskDto>().ReverseMap();
        }
    }
}