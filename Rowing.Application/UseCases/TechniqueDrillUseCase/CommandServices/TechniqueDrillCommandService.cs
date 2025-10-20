using Microsoft.Extensions.Logging;
using Rowing.Application.Interfaces;

namespace Rowing.Application.DrillTechniqueUseCase.CommandServices;

public class TechniqueDrillCommandService : ITechniqueDrillCommandService
{
    private readonly ITechniqueDrillRepository _drillRepo;
    private readonly ILogger<TechniqueDrillCommandService> _logger;

    public TechniqueDrillCommandService(ITechniqueDrillRepository drillRepo,
        ILogger<TechniqueDrillCommandService> logger)
    {
        _drillRepo = drillRepo;
        _logger = logger;
    }

}