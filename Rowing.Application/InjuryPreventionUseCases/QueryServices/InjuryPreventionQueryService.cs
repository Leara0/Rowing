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
        return domainEntity.Select(entity =>
        {
            var dto = new InjuryPreventionDto(entity);
            dto.RiskPhase = new StrokePhaseWrapperDto
            {
                Selected = Enum.Parse<StrokePhaseWrapperDto.StrokePhase>(entity.RiskPhaseName)
            };
            return dto;
        });
    }

    public async Task<InjuryPreventionDto?> GetInjuryPreventionByIdAsync(int id)
    {
        var domainEntity = await _injuryRepo.GetInjuryPreventionByIdAsync(id);
        if (domainEntity == null)
            return null;
        var dto = new InjuryPreventionDto(domainEntity);
        
        dto.RiskPhase = new StrokePhaseWrapperDto
        {
            Selected = Enum.Parse<StrokePhaseWrapperDto.StrokePhase>(domainEntity.RiskPhaseName)
        };
        
        return dto;
    }

}