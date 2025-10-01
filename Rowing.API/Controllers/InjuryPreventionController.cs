using Microsoft.AspNetCore.Mvc;
using Rowing.Application.Exceptions;
using Rowing.Application.InjuryPreventionUseCases;


namespace Rowing.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InjuryPreventionController : ControllerBase
{
    private readonly ILogger<InjuryPreventionController> _logger;
    private readonly IInjuryPreventionService _preventionService;

    public InjuryPreventionController(ILogger<InjuryPreventionController> logger,
        IInjuryPreventionService preventionService)
    {
        _logger = logger;
        _preventionService = preventionService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<InjuryPreventionDto>>> GetAll()
    {
        _logger.LogInformation("Getting all injury preventions");
        var result = await _preventionService.GetAllInjuryPreventionsAsync();
        return Ok(result);
        //call service layer to get all injury prevention datas
        //SL calls repo to get all data

    }

    [HttpGet("{id}")]
    public async Task<ActionResult<InjuryPreventionDto>> GetById(int id)
    {
        _logger.LogInformation("Getting injury prevention by id {0}", id);
        var result = await _preventionService.GetInjuryPreventionByIdAsync(id);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpGet("{id}/edit")]
    public async Task<ActionResult<UpdateInjuryPrevResponseDto>> GetInjuryPreventionForEdit(int id)
    {
        _logger.LogInformation("Getting injury prevention by id {id}", id);
        var result = await _preventionService.GetInjuryPreventionForEditAsync(id);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateInjuryPrevention(int id, UpdateInjuryPrevRequestDto dto)
    {
        //check if the data is valid doing that model state thing
        if (!ModelState.IsValid) return BadRequest(ModelState);
        
        try //send the dto to the service layer
        {
            await _preventionService.UpdateInjuryPreventionAsync(id, dto);
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}