using Rowing.Application.Interfaces;

namespace Rowing.Application.StrokePhase;

public class StrokePhaseService :IStrokePhaseService
{
    private readonly IStrokePhaseRepository _strokePhaseRepo;
    public StrokePhaseService(IStrokePhaseRepository strokePhaseRepository)
    {
        _strokePhaseRepo = strokePhaseRepository;
    }
    public async Task<IEnumerable<StrokePhaseDto>> GetAllStrokePhasesAsync()
    {
        //get IEnumerable of domain entities from repo
        var domainEntities = await _strokePhaseRepo.GetAllStrokePhasesAsync();
        //map the entities to DTOs and return
        return domainEntities.Select(x => new StrokePhaseDto(x));
    }

    public async Task<StrokePhaseDto?> GetStrokePhaseById(int id)
    {
        //get specific StrokePhase from the Db
        var domainEntity = await _strokePhaseRepo.GetStrokePhaseById(id);
        // map entity to DTO and return
        return domainEntity == null ? null : new StrokePhaseDto(domainEntity);
    }
}