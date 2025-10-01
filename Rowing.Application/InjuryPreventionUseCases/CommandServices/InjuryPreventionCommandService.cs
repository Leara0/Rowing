using Microsoft.Extensions.Logging;
using Rowing.Application.Exceptions;
using Rowing.Application.Interfaces;

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
    public async Task UpdateInjuryPreventionAsync(int id, UpdateInjuryPrevRequestDto dto)
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
}