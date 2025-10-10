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
        throw new NotImplementedException();
    }
}