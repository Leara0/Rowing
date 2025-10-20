namespace Rowing.Application.InjuryPreventionUseCases;

public interface IInjuryPreventionCommandService
{
    public Task UpdateInjuryPreventionAsync(int id, UpdateCreateInjuryPreventionDto dto);
    public Task<int> CreateInjuryPreventionAsync(UpdateCreateInjuryPreventionDto dto);
    public Task DeleteInjuryPreventionAsync(int id);
}