using Microsoft.AspNetCore.Mvc;
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
        var result =  await _strokeService.GetStrokePhaseById(id);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<StrokePhaseDto>> Update(int id, UpdateStrokePhaseDto strokeDto)
    {
        try
        {
            var result = await _strokeService.UpdateKeyFocus(id, strokeDto.KeyFocus);
            return result == null ? NotFound() : Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500, ex.Message);
        }
    }
}