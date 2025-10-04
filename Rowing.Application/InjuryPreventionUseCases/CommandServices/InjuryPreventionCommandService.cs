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
        //fetch domain entity and set hidden fields
        var domainEntity = await _injuryRepo.GetInjuryPreventionByIdAsync(id);
        if (domainEntity == null) //if the record is missing log an error
        {
            _logger.LogError("Invalid injury prevention id {id}. No records were updated", id);
            throw new NotFoundException($"Injury prevention with id {id} not found");
        }

        domainEntity.IsVerified = false;
        domainEntity.BodyArea = dto.BodyArea;
        domainEntity.InjuryType = dto.InjuryType;
        domainEntity.PreventionStrategy = dto.PreventionStrategy;
        domainEntity.StrengtheningExercises = dto.StrengtheningExercises;
        domainEntity.CriticalPhaseId = (int)dto.RiskPhase.Selected;
        domainEntity.Id = id;

        //send this to the repository to overwrite the current record
        await _injuryRepo.UpdateInjuryPreventionAsync(domainEntity);
        //no exception handling here since we just checked that the id was valid in the previous step
    }

    public async Task<int> CreateInjuryPreventionAsync(UpdateCreateInjuryPreventionDto dto)
    {
        //create a new domain entity and set all the fields
        var domainEntity = new InjuryPrevention(dto.BodyArea, dto.InjuryType, dto.PreventionStrategy,
            dto.StrengtheningExercises);
        domainEntity.CriticalPhaseId = (int)dto.RiskPhase.Selected;
        domainEntity.IsVerified = false;
        domainEntity.CreatedAt = DateTime.UtcNow;
        domainEntity.CreatedBy = "user";
        
        //send it to the repository and get the int back
        return await _injuryRepo.CreateInjuryPreventionAsync(domainEntity);
    }
}