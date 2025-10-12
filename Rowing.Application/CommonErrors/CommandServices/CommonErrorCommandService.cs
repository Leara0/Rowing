using Microsoft.Extensions.Logging;
using Rowing.Application.Interfaces;
using Rowing.Domain.Entities;

namespace Rowing.Application.CommonErrors.CommandServices;

public class CommonErrorCommandService: ICommonErrorCommandService
{
    private readonly ICommonErrorRepository _commonErrorRepo;
    private readonly ILogger<CommonErrorCommandService> _logger;

    public CommonErrorCommandService(ICommonErrorRepository commonErrorRepo, ILogger<CommonErrorCommandService> logger)
    {
        _commonErrorRepo = commonErrorRepo;
        _logger = logger;
    }
    public Task UpdateCommonErrorAsync(int id, UpdateCreateCommonErrorDto dto)
    {
        //create a new domain entity
        //set the given fields
        //translate the enums
        //send it to the repo
        //throw an error if the num returned isn't 1

        var domainEntity = new CommonError(dto.Name, dto.Description, dto.Cause, dto.CorrectionStrategy);
        domainEntity.SetStrokePhaseId((int)dto.RiskPhase.Selected);
        domainEntity.SetRelatedInjuryId((int)dto.RelatedInjuryBodyArea.Selected);
        domainEntity.IsVerified = false;

        var rowsAffected = _commonErrorRepo.UpdateCommonErrorAsync(domainEntity);
        
        if (rowsAffected ~=)
        
        throw new NotImplementedException();
    }
}