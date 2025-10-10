using Microsoft.Extensions.Logging;
using Rowing.Application.DTOs;
using Rowing.Application.Interfaces;

namespace Rowing.Application.CommonErrors.QueryServices;

public class CommonErrorQueryService: ICommonErrorQueryService
{
    private readonly ICommonErrorRepository _commonErrorRepo;
    private readonly ILogger<CommonErrorQueryService> _logger;

    public CommonErrorQueryService(ICommonErrorRepository commonErrorRepo, ILogger<CommonErrorQueryService> logger)
    {
        _commonErrorRepo = commonErrorRepo;
        _logger = logger;
    }

    public async Task<IEnumerable<CommonErrorDto>> GetAllCommonErrorsAsync()
    {
        var domainEntity = await _commonErrorRepo.GetAllCommonErrorsAsync();
        return domainEntity.Select(entity =>
        {
            var dto = new CommonErrorDto(entity);
            dto.RiskPhase = new StrokePhaseWrapperDto
            {
                Selected = Enum.Parse<StrokePhaseWrapperDto.StrokePhase>(entity.StrokePhaseName)
            };
            dto.RelatedInjuryBodyArea = new InjuryPreventionWrapperDto
            {
                Selected = Enum.Parse<InjuryPreventionWrapperDto.InjuryBodyArea>(entity.RelatedInjuryBodyArea)
            };
            return dto;
        });
    }

    public async Task<CommonErrorDto?> GetCommonErrorByIdAsync(int id)
    {
        //get the domain entity from the repository
        //create the dto and set the properties using the custom constructor
        //map the risk phase and related injury body area properties
        //return the dto
        var domainEntity = await _commonErrorRepo.GetCommonErrorByIdAsync(id);
        if (domainEntity == null) 
            return null;
        var dto = new CommonErrorDto(domainEntity);
        dto.RiskPhase = new StrokePhaseWrapperDto
        {
            Selected = Enum.Parse<StrokePhaseWrapperDto.StrokePhase>(domainEntity.StrokePhaseName)
        };
        dto.RelatedInjuryBodyArea = new InjuryPreventionWrapperDto
        {
            Selected = Enum.Parse<InjuryPreventionWrapperDto.InjuryBodyArea>(domainEntity.RelatedInjuryBodyArea)
        };
        return dto;
    }
}