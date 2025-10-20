using Microsoft.Extensions.Logging;
using Rowing.Application.Exceptions;
using Rowing.Application.Interfaces;
using Rowing.Domain.Entities;

namespace Rowing.Application.StrokePhase;

public class StrokePhaseService :IStrokePhaseService
{
    private readonly IStrokePhaseRepository _strokePhaseRepo;
    private readonly ILogger<StrokePhaseService> _logger;
    public StrokePhaseService(IStrokePhaseRepository strokePhaseRepository, ILogger<StrokePhaseService> logger)
    {
        _strokePhaseRepo = strokePhaseRepository;
        _logger = logger;
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
        var domainEntity = await _strokePhaseRepo.GetStrokePhaseByIdAsync(id);
        // map entity to DTO and return
        return domainEntity == null ? null : new StrokePhaseDto(domainEntity);
    }

    public async Task UpdateKeyFocus(int id, UpdateStrokePhaseDto dto)
    {
        //make a new domain entity so it has to pass through the domain validation
        var domainEntity = new Domain.Entities.StrokePhase();
        domainEntity.SetKeyFocus(dto.KeyFocus);
        
        //call the repo with the update information
        var rowsAffected = await _strokePhaseRepo.UpdateKeyFocusAsync(id, domainEntity.KeyFocus);

        if (rowsAffected != 1) //if no record was updated because none could be found with this id
        {
            _logger.LogError("Invalid stroke phase id {id}. No records were updated", id);
            throw new NotFoundException($"Stroke Phase record with id {id} not found");
        }
    }
}