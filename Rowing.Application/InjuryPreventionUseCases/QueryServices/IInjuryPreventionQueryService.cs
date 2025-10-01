namespace Rowing.Application.InjuryPreventionUseCases;

public interface IInjuryPreventionQueryService
{
    public Task<IEnumerable<InjuryPreventionDto>> GetAllInjuryPreventionsAsync();
    public Task<InjuryPreventionDto?> GetInjuryPreventionByIdAsync(int id);
    public Task<UpdateInjuryPrevResponseDto?> GetInjuryPreventionForEditAsync(int id); 
}