using Rowing.Application.Interfaces;

namespace Rowing.Application.StrokePhase;

public class StrokePhaseService :IStrokePhaseService
{
    private readonly IStrokePhaseRepo _strokePhaseRepo;
    public StrokePhaseService(IStrokePhaseRepo strokePhaseRepo)
    {
        _strokePhaseRepo = strokePhaseRepo;
    }
    public Task<IEnumerable<StrokePhaseDto>> GetAllStrokePhasesAsync()
    {
        //get all stroke phase domain entities from the repo
        //map the entities to DTOs
        //return the DTOs
        throw new NotImplementedException();
    }

    public Task<StrokePhaseDto> GetStrokePhaseById(int id)
    {
        throw new NotImplementedException();
    }
}