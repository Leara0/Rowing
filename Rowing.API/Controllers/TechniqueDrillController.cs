using Microsoft.AspNetCore.Mvc;
using Rowing.Application.DrillTechniqueUseCase.CommandServices;
using Rowing.Application.DrillTechniqueUseCase.QueryServices;

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
        var result = await _queryService.GetAllTechniqueDrillAsync();
        return Ok(result);
    }
}