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
    public async Task<ActionResult> Update(int id, UpdateCreateTechniqueDrillDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        
        try
        {
            _commandService.UpdateTechniqueDrillAsync(id, dto);
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
    public async Task<ActionResult> Create(UpdateCreateTechniqueDrillDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        try
        {
            var newId = await _commandService.CreateTechniqueDrillAsync(dto);
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
            await _commandService.DeleteTechniqueDrillAsync(id);
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}