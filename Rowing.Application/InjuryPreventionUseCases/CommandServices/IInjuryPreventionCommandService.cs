namespace Rowing.Application.InjuryPreventionUseCases;

public interface IInjuryPreventionCommandService
{
    public Task UpdateInjuryPreventionAsync(int id, UpdateInjuryPrevRequestDto dto);
}