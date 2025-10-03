using Microsoft.Extensions.Logging;
using Rowing.Application.DTOs;
using Rowing.Application.Interfaces;

namespace Rowing.Application.InjuryPreventionUseCases;

public class InjuryPreventionQueryService : IInjuryPreventionQueryService
{
    private readonly IInjuryPreventionRepository _injuryRepo;
    private readonly IStrokePhaseRepository _strokeRepo;
    private readonly ILogger<InjuryPreventionQueryService> _logger;

    public InjuryPreventionQueryService(IInjuryPreventionRepository injuryRepo, IStrokePhaseRepository strokeRepo,
        ILogger<InjuryPreventionQueryService> logger)
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
        if (domainEntity == null)
            return null;
        var dto = new InjuryPreventionDto(domainEntity);
        
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

}