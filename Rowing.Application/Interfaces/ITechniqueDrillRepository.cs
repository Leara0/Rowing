using Rowing.Domain.Entities;

namespace Rowing.Application.Interfaces;

public interface ITechniqueDrillRepository
{
    public Task<IEnumerable<TechniqueDrill>> GetAllTechniqueDrillAsync();
    public Task<TechniqueDrill?> GetTechniqueDrillByIdAsync(int id);
    public Task<int> UpdateTechniqueDrillAsync(TechniqueDrill model);
    public Task<int> CreateTechniqueDrillAsync(TechniqueDrill model);
    public Task<int> DeleteTechniqueDrillAsync(int id);
    public Task<IEnumerable<TechniqueDrill>> SearchAsync(string searchTerm);
    public Task<IEnumerable<TechniqueDrill>> SearchAsync(string searchTerm, string field);
}