using Microsoft.AspNetCore.Mvc;
using Rowing.Application.CommonErrors.CommandServices;
using Rowing.Application.CommonErrors.QueryServices;
using Rowing.Application.Exceptions;

namespace Rowing.API.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CommonErrorController : ControllerBase
{
    private readonly ICommonErrorCommandService _commandService;
    private readonly ICommonErrorQueryService _queryService;
    private readonly ILogger<CommonErrorController> _logger;

    public CommonErrorController(ICommonErrorCommandService commandService, ICommonErrorQueryService queryService,
        ILogger<CommonErrorController> logger)
    {
        _commandService = commandService;
        _queryService = queryService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CommonErrorDto>>> GetAll()
    {
        var result = await _queryService.GetAllCommonErrorsAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CommonErrorDto>> GetById(int id)
    {
        var result = await _queryService.GetCommonErrorByIdAsync(id);
        return result == null ? NotFound() : Ok(result);
        
        //steps:
        //call the application layer with the id
        // calls the repo with the id
        //return the record or not found exception
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCommonError(int id, UpdateCreateCommonErrorDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        try //try to send the dto to the database
        {
            await _commandService.UpdateCommonErrorAsync(id, dto);
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
        
        
        //steps:
        //check validity of model state
        //send the dto to the application layer (pull out enum to num, set admin fields)
        //send to repository (returns num of rows affected)
        //app throws not found exception if rows != 1??
        throw new NotImplementedException();
    }
}