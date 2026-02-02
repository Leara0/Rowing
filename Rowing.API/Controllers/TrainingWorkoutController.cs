using Microsoft.AspNetCore.Mvc;
using Rowing.Application.UseCases.TrainingWorkoutsUseCase.CommandServices;
using Rowing.Application.UseCases.TrainingWorkoutsUseCase.QueryServices;

namespace Rowing.API.Controllers;
[ApiController]
[Route("api/[controller]")]


public class TrainingWorkoutController : Controller
{
    private readonly ILogger<TrainingWorkoutController> _logger;
    private readonly ITrainingWorkoutQueryService _queryService;
    private readonly ITrainingWorkoutCommandService _commandService;

    public TrainingWorkoutController(ILogger<TrainingWorkoutController> logger, ITrainingWorkoutQueryService query,
        ITrainingWorkoutCommandService command)
    {
        _logger = logger;
        _queryService = query;
        _commandService = command;
    }
    
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TrainingWorkoutDto>>> GetAll()
    {
        var results = await _queryService.GetAllTrainingWorkoutAsync();
        return Ok(results);
    }
    
  
}