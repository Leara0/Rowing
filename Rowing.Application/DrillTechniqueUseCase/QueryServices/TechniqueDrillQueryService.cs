using Microsoft.Extensions.Logging;
using Rowing.Application.Interfaces;

namespace Rowing.Application.DrillTechniqueUseCase.QueryServices;

public class TechniqueDrillQueryService : ITechniqueDrillQueryService
{
    private readonly ITechniqueDrillRepository _drillRepo;
    private readonly ILogger<TechniqueDrillQueryService> _logger;

    public TechniqueDrillQueryService(ITechniqueDrillRepository drillRepo, ILogger<TechniqueDrillQueryService> logger)
    {
        _drillRepo = drillRepo;
        _logger = logger;
    }
}