namespace Rowing.Application.Interfaces;
using Rowing.Domain.Entities;

public interface IInjuryPreventionRepository
{
    public Task<IEnumerable<InjuryPrevention>> GetAllInjuryPreventionsAsync();
    public Task<InjuryPrevention?> GetInjuryPreventionByIdAsync(int id);
}