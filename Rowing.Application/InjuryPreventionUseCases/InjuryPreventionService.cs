using Rowing.Application.DTOs;
using Rowing.Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace Rowing.Application.InjuryPreventionUseCases;

public class InjuryPreventionService :IInjuryPreventionService
{
    private readonly IInjuryPreventionRepository _injuryRepo;
    private readonly IStrokePhaseRepository _strokeRepo;
    private readonly ILogger<InjuryPreventionService> _logger;

    public InjuryPreventionService(IInjuryPreventionRepository injuryRepo, IStrokePhaseRepository strokeRepo, ILogger<InjuryPreventionService> logger)
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

    public async Task<UpdateInjuryPreventionDto?> GetInjuryPreventionForEditAsync(int id)
    {
        var domainEntity = await _injuryRepo.GetInjuryPreventionByIdAsync(id);
        if (domainEntity == null)
            return null;
        var dto = new UpdateInjuryPreventionDto(domainEntity);

        try
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
}