using Microsoft.Extensions.Logging;
using Rowing.Application.Exceptions;
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
    public async Task UpdateCommonErrorsAsync(int id, UpdateCreateCommonErrorDto dto)
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
        domainEntity.ErrorId = id;

        var rowsAffected = await _commonErrorRepo.UpdateCommonErrorAsync(domainEntity);

        if (rowsAffected != 1) //if no recored match this id then no rows will be affected
        {
            _logger.LogError("Invalid common errors id {id}. No records were updated", id);
            throw new NotFoundException($"Common errors record with id {id} not found");
        }
    }
    public Task<int> CreateCommonErrorsAsync(UpdateCreateCommonErrorDto dto)
    {
        //create a new domain entity
        //set all the fields (including the enums and admin fields)
        //send to repo and get id back
        //return id to controller
        var domainEntity = new CommonError(dto.Name, dto.Description, dto.Cause, dto.CorrectionStrategy);
        domainEntity.SetStrokePhaseId((int)dto.RiskPhase.Selected);
        domainEntity.SetRelatedInjuryId((int)dto.RelatedInjuryBodyArea.Selected);
        domainEntity.IsVerified = false;
        domainEntity.CreatedAt = DateTime.UtcNow;
        domainEntity.CreatedBy = "user";

        return _commonErrorRepo.CreateCommonErrorsAsync(domainEntity);
    }

    public async Task DeleteCommonErrorsAsync(int id)
    {
        var rowsAffected = await _commonErrorRepo.DeleteCommonErrorsAsync(id);

        if (rowsAffected != 1)//if no record matching id was found
        {
            _logger.LogError("Invalid common errors id {id}. No records were deleted.", id);
            throw new NotFoundException($"Common errors record with id {id} not found.");
        }
    }
}