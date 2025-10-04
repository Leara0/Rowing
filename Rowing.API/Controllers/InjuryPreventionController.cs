using Microsoft.AspNetCore.Mvc;
using Rowing.Application.Exceptions;
using Rowing.Application.InjuryPreventionUseCases;


namespace Rowing.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InjuryPreventionController : ControllerBase
{
    private readonly ILogger<InjuryPreventionController> _logger;
    private readonly IInjuryPreventionQueryService _queryService;
    private readonly IInjuryPreventionCommandService _commandService;

    public InjuryPreventionController(ILogger<InjuryPreventionController> logger,
        IInjuryPreventionQueryService queryService,
        IInjuryPreventionCommandService commandService)
    {
        _logger = logger;
        _queryService = queryService;
        _commandService = commandService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<InjuryPreventionDto>>> GetAll()
    {
        _logger.LogInformation("Getting all injury preventions");
        var result = await _queryService.GetAllInjuryPreventionsAsync();
        return Ok(result);
        //call service layer to get all injury prevention datas
        //SL calls repo to get all data

    }

    [HttpGet("{id}")]
    public async Task<ActionResult<InjuryPreventionDto>> GetById(int id)
    {
        _logger.LogInformation("Getting injury prevention by id {0}", id);
        var result = await _queryService.GetInjuryPreventionByIdAsync(id);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateInjuryPrevention(int id, UpdateCreateInjuryPreventionDto dto)
    {
        //check if the data is valid doing that model state thing
        if (!ModelState.IsValid) return BadRequest(ModelState);
        
        try //send the dto to the service layer
        {
            await _commandService.UpdateInjuryPreventionAsync(id, dto);
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> CreateInjuryPrevention(UpdateCreateInjuryPreventionDto dto)
    {
        //check if modelstate is valid
        if (!ModelState.IsValid) return BadRequest(ModelState);

        try //try to send it to the database
        {
            var newId = await _commandService.CreateInjuryPreventionAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = newId }, newId);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to create injury prevention record");
            return StatusCode(500, "An error occured creating the new record");
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteInjuryPrevention(int id)
    {
        //call the service layer
        //call the repository
        //check for rows affected
        //return results
        throw new NotImplementedException();
    }
}