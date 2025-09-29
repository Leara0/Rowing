namespace Rowing.Application.InjuryPreventionUseCases;

public interface IInjuryPreventionService
{
    public Task<IEnumerable<InjuryPreventionDto>> GetAllInjuryPreventionsAsync();
    public Task<InjuryPreventionDto?> GetInjuryPreventionByIdAsync(int id);
    public Task<UpdateInjuryPreventionDto?> GetInjuryPreventionForEditAsync(int id);
}