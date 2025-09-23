using Microsoft.AspNetCore.Mvc;
using Rowing.Application.StrokePhase;

namespace Rowing.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StrokePhasesController : ControllerBase
{
    private readonly IStrokePhaseService _strokeService;

    public StrokePhasesController(IStrokePhaseService strokeService)
    {
        _strokeService = strokeService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StrokePhaseDto>>> GetAll()
    {
        var result = await _strokeService.GetAllStrokePhasesAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<StrokePhaseDto>> GetById(int id)
    {
        var result =  await _strokeService.GetStrokePhaseById(id);
        return result == null ? NotFound() : Ok(result);
    }
}