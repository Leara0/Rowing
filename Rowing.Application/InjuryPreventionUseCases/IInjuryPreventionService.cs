using Rowing.Domain.Entities;

namespace Rowing.Application.InjuryPreventionUseCases;

public interface IInjuryPreventionService
{
    public Task<IEnumerable<InjuryPreventionDto>> GetAllInjuryPreventionsAsync();
    public Task<InjuryPreventionDto?> GetInjuryPreventionByIdAsync(int id);
    public Task<UpdateInjuryPrevResponseDto?> GetInjuryPreventionForEditAsync(int id);
    public Task UpdateInjuryPreventionAsync(int id, UpdateInjuryPrevRequestDto dto1);
}