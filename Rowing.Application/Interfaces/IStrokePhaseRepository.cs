namespace Rowing.Application.Interfaces;
using Rowing.Domain.Entities;

public interface IStrokePhaseRepository
{
    public Task<IEnumerable<StrokePhase>> GetAllStrokePhasesAsync();
    public Task<StrokePhase?> GetStrokePhaseByIdAsync(int id);
    public Task<StrokePhase?> UpdateKeyFocusAsync(int id, string keyFocus);
}