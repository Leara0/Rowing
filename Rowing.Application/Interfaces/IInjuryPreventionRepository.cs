namespace Rowing.Application.Interfaces;
using Rowing.Domain.Entities;

public interface IInjuryPreventionRepository
{
    public Task<IEnumerable<InjuryPrevention>> GetAllInjuryPreventionsAsync();
    public Task<InjuryPrevention?> GetInjuryPreventionByIdAsync(int id);
    public Task<int> UpdateInjuryPreventionAsync(InjuryPrevention model);
    public Task<int> CreateInjuryPreventionAsync(InjuryPrevention model);
    public Task<bool> HasDependentRecordsAsync(int injuryId);
    public Task<int> DeleteInjuryPreventionAsync(int id);

}