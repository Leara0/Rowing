using Rowing.Domain.Entities;

namespace Rowing.Application.Interfaces;

public interface ITechniqueDrillRepository
{
    public Task<IEnumerable<TechniqueDrill>> GetAllTechniqueDrillAsync();
    public Task<TechniqueDrill?> GetTechniqueDrillByIdAsync(int id);
    public Task<int> UpdateTechniqueDrillAsync(TechniqueDrill model);
}