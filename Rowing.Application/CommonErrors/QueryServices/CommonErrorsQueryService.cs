using Microsoft.Extensions.Logging;
using Rowing.Application.DTOs;
using Rowing.Application.Interfaces;

namespace Rowing.Application.CommonErrors.QueryServices;

public class CommonErrorsQueryService: ICommonErrorsQueryService
{
    private readonly ICommonErrorsRepository _commonErrorsRepo;
    private readonly ILogger<CommonErrorsQueryService> _logger;

    public CommonErrorsQueryService(ICommonErrorsRepository commonErrorsRepo, ILogger<CommonErrorsQueryService> logger)
    {
        _commonErrorsRepo = commonErrorsRepo;
        _logger = logger;
    }

    public async Task<IEnumerable<CommonErrorsDto>> GetAllCommonErrorsAsync()
    {
        var domainEntity = await _commonErrorsRepo.GetAllCommonErrorsAsync();
        return domainEntity.Select(entity =>
        {
            var dto = new CommonErrorsDto(entity);
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
        throw new NotImplementedException();
    }
}