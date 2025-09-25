using Rowing.Application.Interfaces;

namespace Rowing.Application.InjuryPreventionUseCases;

public class InjuryPreventionService :IInjuryPreventionService
{
    private readonly IInjuryPreventionRepository _injuryRepo;

    public InjuryPreventionService(IInjuryPreventionRepository injuryRepo)
    {
        _injuryRepo = injuryRepo;
    }

}