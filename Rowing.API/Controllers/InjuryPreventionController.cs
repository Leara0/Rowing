using Microsoft.AspNetCore.Mvc;
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
    public async void Index()
    {
        
    }
}