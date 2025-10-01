using System.Globalization;
using Rowing.Application.DTOs;
using Rowing.Application.Interfaces;
using Microsoft.Extensions.Logging;
using Rowing.Application.Exceptions;



namespace Rowing.Application.InjuryPreventionUseCases;

public class InjuryPreventionService : IInjuryPreventionService
{
    private readonly IInjuryPreventionRepository _injuryRepo;
    private readonly IStrokePhaseRepository _strokeRepo;
    private readonly ILogger<InjuryPreventionService> _logger;

    public InjuryPreventionService(IInjuryPreventionRepository injuryRepo, IStrokePhaseRepository strokeRepo,
        ILogger<InjuryPreventionService> logger)
    {
        _injuryRepo = injuryRepo;
        _strokeRepo = strokeRepo;
        _logger = logger;
    }

    public async Task<IEnumerable<InjuryPreventionDto>> GetAllInjuryPreventionsAsync()
    {
        var domainEntity = await _injuryRepo.GetAllInjuryPreventionsAsync();
        return domainEntity.Select(x => new InjuryPreventionDto(x));
    }

    public async Task<InjuryPreventionDto?> GetInjuryPreventionByIdAsync(int id)
    {
        var domainEntity = await _injuryRepo.GetInjuryPreventionByIdAsync(id);
        return domainEntity == null ? null : new InjuryPreventionDto(domainEntity);
    }

    public async Task<UpdateInjuryPrevResponseDto?> GetInjuryPreventionForEditAsync(int id)
    {
        var domainEntity = await _injuryRepo.GetInjuryPreventionByIdAsync(id);
        if (domainEntity == null)
            return null;
        var dto = new UpdateInjuryPrevResponseDto(domainEntity);

        try //this block checks the RiskPhaseName to ensure it is a member of the StrokePhase enum
        {
            dto.RiskPhase = new StrokePhaseWrapperDto
            {
                Selected = Enum.Parse<StrokePhaseWrapperDto.StrokePhase>(domainEntity.RiskPhaseName)
            };
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex, "Invalid stroke phase '{RiskPhaseName}' for injury prevention id {id}",
                domainEntity.RiskPhaseName, id);
            dto.RiskPhase = new StrokePhaseWrapperDto()
            {
                Selected = null
            };
        }

        return dto;
    }

    public async Task UpdateInjuryPreventionAsync(int id, UpdateInjuryPrevRequestDto dto1)
    {
        //fetch domain entity and set hidden fields
        var domainEntity = await _injuryRepo.GetInjuryPreventionByIdAsync(id);
        if (domainEntity == null) //if the record is missing log an error
        {
            _logger.LogError("Invalid injury prevention id {id}. No records were updated", id);
            throw new NotFoundException($"Injury prevention with id {id} not found");
        }

        domainEntity.IsVerified = false;
        domainEntity.BodyArea = dto1.BodyArea;
        domainEntity.InjuryType = dto1.InjuryType;
        domainEntity.PreventionStrategy = dto1.PreventionStrategy;
        domainEntity.StrengtheningExercises = dto1.StrengtheningExercises;
        domainEntity.CriticalPhaseId = (int)dto1.RiskPhase.Selected;
        domainEntity.Id = id;

        //send this to the repository to overwrite the current record
        await _injuryRepo.UpdateInjuryPreventionAsync(domainEntity);
        //no exception handling here since we just checked that the id was valid in the previous step
     }
}