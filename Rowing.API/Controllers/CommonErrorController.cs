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
        //steps:
        //call the application layer with the id
        //app layer calls the repo with the id
        //return the record or not found exception
        var result = await _queryService.GetCommonErrorByIdAsync(id);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCommonErrors(int id, UpdateCreateCommonErrorDto dto)
    {
        //steps:
        //check validity of model state
        //send the dto to the application layer (pull out enum to num, set admin fields)
        //send to repository (returns num of rows affected)
        //app throws not found exception if rows != 1??
        //app throws argument exception if domain validation fails
        if (!ModelState.IsValid) return BadRequest(ModelState);

        try //try to send the dto to the database
        {
            await _commandService.UpdateCommonErrorsAsync(id, dto);
            return NoContent();
        }
        catch (NotFoundException ex)//record doesn't exist 
        {
            return NotFound(ex.Message);
        }
        catch (ArgumentException ex)//domain validation failed
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateCommonErrors(UpdateCreateCommonErrorDto dto)
    {
        //steps:
        //check model state validation
        //controller sends dto to app layer
        //app layer maps to domain Entity, sorts out enum and sets admin fields then sends to repo
        //repo creates a new record
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var newId = await _commandService.CreateCommonErrorsAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = newId }, newId);

        }
        catch (ArgumentException ex)//domain validation failed
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCommonErrors(int id)
    {
        //steps:
        //call app layer with id to delete
        //app layer calls the repo
        //repo deletes the record
        try
        {
            await _commandService.DeleteCommonErrorsAsync(id);
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}