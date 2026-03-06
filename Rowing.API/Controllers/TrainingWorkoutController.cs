using Microsoft.AspNetCore.Mvc;
using Rowing.Application.Exceptions;
using Rowing.Application.UseCases.TrainingWorkoutsUseCase.CommandServices;
using Rowing.Application.UseCases.TrainingWorkoutsUseCase.QueryServices;
using Rowing.Domain.Enums;

namespace Rowing.API.Controllers;
[ApiController]
[Route("api/[controller]")]


public class TrainingWorkoutController : Controller
{
    private readonly ILogger<TrainingWorkoutController> _logger;
    private readonly ITrainingWorkoutQueryService _queryService;
    private readonly ITrainingWorkoutCommandService _commandService;

    public TrainingWorkoutController(ILogger<TrainingWorkoutController> logger, ITrainingWorkoutQueryService query,
        ITrainingWorkoutCommandService command)
    {
        _logger = logger;
        _queryService = query;
        _commandService = command;
    }
    
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TrainingWorkoutDto>>> GetAll()
    {
        var results = await _queryService.GetAllTrainingWorkoutAsync();
        return Ok(results);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TrainingWorkoutDto>> GetById(int id)
    {
        var result = await _queryService.GetTrainingWorkoutByIdAsync(id);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<TrainingWorkoutDto>>> Search(string term, SearchFields.SearchField field)
    {
        if (string.IsNullOrWhiteSpace(term))
            return BadRequest("Search term cannot be empty");
        var result = 
            await _queryService.SearchTrainingWorkoutAsync(term, field.ToString());
        if (!result.Any()) return NotFound("No training workouts found matching your search");
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateCreateTrainingWorkoutDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        try
        {
            _commandService.UpdateTrainingWorkoutAsync(id, dto);
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> Create(UpdateCreateTrainingWorkoutDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        try
        {
            var newId = await _commandService.CreateTrainingWorkoutAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = newId }, newId);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            await _commandService.DeleteTrainingWorkoutAsync(id);
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
    
}