using Rowing.Domain.Entities;

namespace Rowing.Application.Interfaces;

public interface ITechniqueDrillRepository
{
    public Task<IEnumerable<TechniqueDrill>> GetAllTechniqueDrillAsync();
}