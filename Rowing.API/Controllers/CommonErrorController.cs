using Microsoft.AspNetCore.Mvc;
using Rowing.Application.CommonErrors.CommandServices;
using Rowing.Application.CommonErrors.QueryServices;

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
        throw new NotImplementedException();
        //call the application layer with the id
        // call the repo with the id
        //return the record or not found exception
    }
}