using Microsoft.Extensions.Logging;
using Rowing.Application.Exceptions;
using Rowing.Application.Interfaces;
using Rowing.Domain.Entities;

namespace Rowing.Application.InjuryPreventionUseCases;

public class InjuryPreventionCommandService : IInjuryPreventionCommandService
{
    private readonly IInjuryPreventionRepository _injuryRepo;
    private readonly IStrokePhaseRepository _strokeRepo;
    private readonly ILogger<InjuryPreventionCommandService> _logger;

    public InjuryPreventionCommandService(IInjuryPreventionRepository injuryRepo, IStrokePhaseRepository strokeRepo,
        ILogger<InjuryPreventionCommandService> logger)
    {
        _injuryRepo = injuryRepo;
        _strokeRepo = strokeRepo;
        _logger = logger;
    }

    public async Task UpdateInjuryPreventionAsync(int id, UpdateCreateInjuryPreventionDto dto)
    {
        //create new domain entity to store updated feilds
        var domainEntity = new InjuryPrevention(dto.BodyArea, dto.InjuryType, dto.PreventionStrategy,
            dto.StrengtheningExercises);
        domainEntity.IsVerified = false;
        domainEntity.SetCriticalPhaseId((int)dto.RiskPhase.Selected);
        domainEntity.Id = id;
        
        //send this to the repository to overwrite the current record
        var rowsAffected = await _injuryRepo.UpdateInjuryPreventionAsync(domainEntity);
        
        if (rowsAffected != 1) //if no records match this id, no rows will be affected
        {
            _logger.LogError("Invalid injury prevention id {id}. No records were updated", id);
            throw new NotFoundException($"Injury prevention record with id {id} not found");
        }
    }

    public async Task<int> CreateInjuryPreventionAsync(UpdateCreateInjuryPreventionDto dto)
    {
        //create a new domain entity and set all the fields
        var domainEntity = new InjuryPrevention(dto.BodyArea, dto.InjuryType, dto.PreventionStrategy,
            dto.StrengtheningExercises);
        domainEntity.SetCriticalPhaseId((int)dto.RiskPhase.Selected);
        domainEntity.IsVerified = false;
        domainEntity.CreatedAt = DateTime.UtcNow;
        domainEntity.CreatedBy = "user";
        
        //send it to the repository. if creates fails it will throw an error that will be caught by controller
        return await _injuryRepo.CreateInjuryPreventionAsync(domainEntity);
    }

    public async Task DeleteInjuryPreventionAsync(int id)
    {
        var rowsAffected = await _injuryRepo.DeleteInjuryPreventionAsync(id);
        //check what number we get back and create an error if it's not 1
        if (rowsAffected != 1)
        {
            _logger.LogError("Invalid injury prevention id {id}. No records were deleted.", id);
            throw new NotFoundException($"Injury prevention record with id {id} not found");
        }
    }
}