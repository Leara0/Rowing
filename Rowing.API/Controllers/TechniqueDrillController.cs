using Microsoft.AspNetCore.Mvc;
using Rowing.Application.DrillTechniqueUseCase.CommandServices;
using Rowing.Application.DrillTechniqueUseCase.QueryServices;
using Rowing.Application.Exceptions;

namespace Rowing.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TechniqueDrillController : Controller
{
    private readonly ILogger<TechniqueDrillController> _logger;
    private readonly ITechniqueDrillCommandService _commandService;
    private readonly ITechniqueDrillQueryService _queryService;

    public TechniqueDrillController(ILogger<TechniqueDrillController> logger,
        ITechniqueDrillCommandService commandService, ITechniqueDrillQueryService queryService)
    {
        _logger = logger;
        _commandService = commandService;
        _queryService = queryService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TechniqueDrillDto>>> GetAll()
    {
        var results = await _queryService.GetAllTechniqueDrillAsync();
        return Ok(results);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TechniqueDrillDto>> GetById(int id)
    {
        var result = await _queryService.GetTechniqueDrillByIdAsync(id);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateCreateTechniqueDrillDto drillDto)
    {
        try
        {
            _commandService.UpdateTechniqueDrillAsync(id, drillDto);
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
        
        
        
        throw new NotImplementedException();
    }
}