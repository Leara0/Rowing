namespace Rowing.Application.StrokePhase;

public interface IStrokePhaseService
{
    public Task<IEnumerable<StrokePhaseDto>> GetAllStrokePhasesAsync();
    public Task<StrokePhaseDto?> GetStrokePhaseById(int id);
}