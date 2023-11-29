using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskTracker.Bl.Services;
using TaskTracker.Domain.Dtos;
using TaskTracker.Domain.Interfaces.IServices;

namespace TaskTracker.Api.Controllers
{
    [ApiController]
    [Route("api/task")]
    public class TaskController : ControllerBase
    {
        private readonly ICastomTaskService<CastomTaskDto> _castomTaskService;
        private readonly IValidator<CastomTaskDto> _castomTaskDtoValidator;

        public TaskController(
            ICastomTaskService<CastomTaskDto> castomTaskService,
            IValidator<CastomTaskDto> castomTaskDtoValidator)
        {
            _castomTaskService = castomTaskService;
            _castomTaskDtoValidator = castomTaskDtoValidator;
        }
    
        /// <returns>Ok response containing Tasks collection.</returns>
        /// <response code="200">Returns the list of Tasks.</response> 
        /// <response code="404">The base is Empty. Tasks weren't found</response>
        [ProducesResponseType(200, Type = typeof(IList<CastomTaskDto>))]
        [ProducesResponseType(404)]
        [HttpGet("all")]
        public async Task<ActionResult<IList<CastomTaskDto>>> GetAll()
        {
            var tasks = await _castomTaskService.GetAllAsync();

            return tasks == null ? NotFound("CastomTasks was not found") : Ok(tasks);
        }

        /// <param name="id">ID of the Task to get.</param>
        /// <returns>Ok response containing a single Task.</returns>
        /// <response code="200">Returns one Task.</response>
        /// <response code="404">The Task by Id was not found.</response>
        [ProducesResponseType(200, Type = typeof(CastomTaskDto))]
        [ProducesResponseType(404)]
        [HttpGet("{id}")]
        public async Task<ActionResult<CastomTaskDto>> GetById([FromRoute]int id)
        {
            var task = await _castomTaskService.GetByIdAsync(id);

            return task == null ? NotFound("CastomTask not found by Id") : Ok(task);
        }

        /// <param name="castomTaskDto">The Task to be created.</param>
        /// <returns>Ok response succesefully created Task in DATA.</returns>
        /// <response code="201">Task is created.</response>
        [ProducesResponseType(201, Type = typeof(CastomTaskDto))]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CastomTaskDto castomTaskDto)
        {
            var validationResult = await _castomTaskDtoValidator.ValidateAsync(castomTaskDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.ToString());
            }

            var success = await _castomTaskService.CreateAsync(castomTaskDto);

            return success == false ? BadRequest("This CastomTask is already existing") : Ok();
        }

        /// <param name = "id" > The ID of the Task to be updated.</param>
        /// <param name = "castomTaskDto" > The updated Task data.</param>
        /// <response code = "204" > Task is successfuly updated.</response>
        /// <response code="404">The Task by Id was not found.</response>
        [ProducesResponseType(204, Type = typeof(CastomTaskDto))]
        [ProducesResponseType(404)]
        [HttpPut("{id:int}/task")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CastomTaskDto castomTaskDto)
        {
            var validationResult = await _castomTaskDtoValidator.ValidateAsync(castomTaskDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.ToString());
            }

            var success = await _castomTaskService.UpdateAsync(id, castomTaskDto);

            return success == false ? NotFound("CastomTask not found by Id") : NoContent();
        }

        /// <param name="id">The ID of the Task to be removed.</param>
        /// <response code="404">The Task by Id was not found.</response>
        [ProducesResponseType(404)]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deleted = await _castomTaskService.DeleteAsync(id);

            return deleted == false ? NotFound("CastomTask not found by Id") : NoContent();
        }
    }
}