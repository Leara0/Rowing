namespace Rowing.Application.InjuryPreventionUseCases;

public interface IInjuryPreventionService
{
    public Task<IEnumerable<InjuryPreventionDto>> GetAllInjuryPreventionsAsync();
}