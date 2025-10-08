using Rowing.Application.DTOs;
using Rowing.Domain.Entities;

namespace Rowing.Application.CommonErrors.QueryServices;

public class CommonErrorsDto
{
    public int ErrorId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public StrokePhaseWrapperDto RiskPhase { get; set; }
    public string Cause { get; set; }
    public string CorrectionStrategy { get; set; }
    public InjuryPreventionWrapperDto RelatedInjuryBodyArea { get; set; }
    public bool IsVerified { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }

    public CommonErrorsDto(CommonError model)
    {
        ErrorId = model.ErrorId;
        Name = model.Name;
        Description = model.Description;
        Cause = model.Cause;
        CorrectionStrategy = model.CorrectionStrategy;
        IsVerified = model.IsVerified;
        CreatedAt = model.CreatedAt;
        CreatedBy = model.CreatedBy;
    }

}