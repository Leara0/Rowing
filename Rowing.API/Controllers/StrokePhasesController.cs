using Microsoft.AspNetCore.Mvc;
using Rowing.Application.Exceptions;
using Rowing.Application.StrokePhase;

namespace Rowing.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StrokePhasesController : ControllerBase
{
    private readonly ILogger<StrokePhasesController> _logger;
    private readonly IStrokePhaseService _strokeService;

    public StrokePhasesController(ILogger<StrokePhasesController> logger, IStrokePhaseService strokeService)
    {
        _logger = logger;
        _strokeService = strokeService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StrokePhaseDto>>> GetAll()
    {
        _logger.LogInformation("getting the stroke phases");
        var result = await _strokeService.GetAllStrokePhasesAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<StrokePhaseDto>> GetById(int id)
    {
        _logger.LogInformation("getting stroke phase by id");
        var result =  await _strokeService.GetStrokePhaseById(id);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateStrokePhaseDto strokeDto)
    {
        try
        {
            await _strokeService.UpdateKeyFocus(id, strokeDto);
            return NoContent();
        }
        catch (NotFoundException ex) //this catches the case where no record with id could be found to update
        {
            return NotFound(ex.Message);
        }
        catch (ArgumentException ex) //this catches domain validation errors
        {
            return BadRequest(ex.Message);
        }
    }
}