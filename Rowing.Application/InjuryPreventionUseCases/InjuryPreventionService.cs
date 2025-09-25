using Rowing.Application.Interfaces;

namespace Rowing.Application.InjuryPreventionUseCases;

public class InjuryPreventionService :IInjuryPreventionService
{
    private readonly IInjuryPreventionRepository _injuryRepo;

    public InjuryPreventionService(IInjuryPreventionRepository injuryRepo)
    {
        _injuryRepo = injuryRepo;
    }

    public async Task<IEnumerable<InjuryPreventionDto>> GetAllInjuryPreventionsAsync()
    {
        var domainEntity = await _injuryRepo.GetAllInjuryPreventionsAsync();
        return domainEntity.Select(x => new InjuryPreventionDto(x));
    }
}