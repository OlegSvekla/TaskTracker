using AutoMapper;
using Microsoft.Extensions.Logging;
using TaskTracker.Domain.Dtos;
using TaskTracker.Domain.Entities;
using TaskTracker.Domain.Interfaces.IRepositories;
using TaskTracker.Domain.Interfaces.IServices;

namespace TaskTracker.Bl.Services
{
    public class CastomTaskService : ICastomTaskService<CastomTaskDto>
    {
        private readonly ICastomTaskRepository _castomTaskRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CastomTaskService> _logger;

        public CastomTaskService(ICastomTaskRepository castomTaskRepository,
            IMapper mapper,
            ILogger<CastomTaskService> logger)
        {
            _castomTaskRepository = castomTaskRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CastomTaskDto> GetByIdAsync(int id)
        {
            var task = await _castomTaskRepository.GetOneByAsync(expression: _ => _.Id.Equals(id));
            if (task is null) return null;

            return _mapper.Map<CastomTaskDto>(task);
        }

        public async Task<IList<CastomTaskDto>> GetAllAsync()
        {
            var tasks = await _castomTaskRepository.GetAllByAsync();
            if (tasks is null) return null;

            return _mapper.Map<IList<CastomTaskDto>>(tasks);
        }

        public async Task<bool> CreateAsync(CastomTaskDto castomTaskDto)
        {
            var existingTask = await _castomTaskRepository.GetOneByAsync(expression: u => u.Title == castomTaskDto.Title);
            if (existingTask != null) return false;

            var castomTask = _mapper.Map<CastomTask>(castomTaskDto);

            var result = await _castomTaskRepository.CreateAsync(castomTask);
            if (result is null) return false;

            return true;
        }

        public async Task<bool> UpdateAsync(int id, CastomTaskDto castomTaskDto)
        {
            var existingTask = await _castomTaskRepository.GetOneByAsync(expression: userDto => userDto.Id == id);
            if (existingTask is null) return false;
            else
            {
                existingTask.Title = castomTaskDto.Title;
                existingTask.Description = castomTaskDto.Description;

                existingTask.CreationDate = castomTaskDto.CreationDate;
                existingTask.UpdateDate = castomTaskDto.UpdateDate;

                await _castomTaskRepository.UpdateAsync(existingTask);

                return true;
            }
        }

        public async Task<bool> DeleteAsync(int taskId)
        {
            var taskToDelete = await _castomTaskRepository.GetOneByAsync(expression: _ => _.Id.Equals(taskId));
            if (taskToDelete is null) return false;

            await _castomTaskRepository.DeleteAsync(taskToDelete!);

            return true;
        }
    }
}