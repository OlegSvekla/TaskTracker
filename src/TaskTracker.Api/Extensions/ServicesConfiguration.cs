using FluentValidation;
using TaskTracker.Domain.Dtos;
using TaskTracker.Domain.Interfaces.IRepositories;
using TaskTracker.Domain.Validation;
using TaskTracker.Infrastructure.Data.Repositories;
using TaskTracker.Infrastructure.Mapper;

namespace TaskTracker.Api.Extensions
{
    public static class ServicesConfiguration
    {
        public static void Configuration(
            IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICastomTaskRepository, CastomTaskRepository>();

            services.AddScoped<ICastomTaskService<CastomTaskDto>, CastomTaskService>();

            services.AddScoped<IValidator<CastomTaskDto>, CastomTaskDtoValidator>();

            services.AddAutoMapper(typeof(MapperEntityToDto));
        }
    }
}