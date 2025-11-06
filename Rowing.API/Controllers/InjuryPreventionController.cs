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
        var results = await _queryService.GetAllInjuryPreventionsAsync();
        return Ok(results);
        //call service layer to get all injury prevention datas
        //SL calls repo to get all data

    }

    [HttpGet("{id}")]
    public async Task<ActionResult<InjuryPreventionDto>> GetById(int id)
    {
        //steps:
        //call the application layer with the id
        //app layer calls the repo with the id
        //return the record or not found exception
        var result = await _queryService.GetInjuryPreventionByIdAsync(id);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateInjuryPrevention(int id, UpdateCreateInjuryPreventionDto dto)
    {
        //steps:
        //check validity of model state
        //send the dto to the application layer (pull out enum to num, set admin fields)
        //send to repository (returns num of rows affected)
        //app throws not found exception if rows != 1??
        //app throws argument exception if domain validation fails
        
        if (!ModelState.IsValid) return BadRequest(ModelState);

        try //send the dto to the service layer
        {
            await _commandService.UpdateInjuryPreventionAsync(id, dto);
            return NoContent();
        }
        catch (NotFoundException ex)//if no record is found matching id
        {
            return NotFound(ex.Message);
        }
        catch (ArgumentException ex) // if updated object fails at domain validation
        {
            return BadRequest(ex.Message);
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
        //this checks for any errors that are due to failure to pass domain validation 
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteInjuryPrevention(int id)
    {
        try
        {
            await _commandService.DeleteInjuryPreventionAsync(id);
            return NoContent();
        }
        //this catches when you try to delete a referenced record
        catch (DependencyException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        //this checks for any errors that are due to failure to pass domain validation 
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}