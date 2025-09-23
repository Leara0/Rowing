namespace Rowing.Application.Interfaces;
using Rowing.Domain.Entities;

public interface IStrokePhaseRepository
{
    public Task<IEnumerable<StrokePhase>> GetAllStrokePhasesAsync();
    public Task<StrokePhase?> GetStrokePhaseById(int id);
}