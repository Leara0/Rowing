using Microsoft.AspNetCore.Mvc;
using Rowing.Application.CommonErrors.CommandServices;
using Rowing.Application.CommonErrors.QueryServices;

namespace Rowing.API.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CommonErrorsController : ControllerBase
{
    private readonly ICommonErrorsCommandService _commandService;
    private readonly ICommonErrorsQueryService _queryService;
    private readonly ILogger<CommonErrorsController> _logger;

    public CommonErrorsController(ICommonErrorsCommandService commandService, ICommonErrorsQueryService queryService,
        ILogger<CommonErrorsController> logger)
    {
        _commandService = commandService;
        _queryService = queryService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CommonErrorsDto>>> GetAll()
    {
        var result = await _queryService.GetAllCommonErrorsAsync();
        return Ok(result);

    }
}