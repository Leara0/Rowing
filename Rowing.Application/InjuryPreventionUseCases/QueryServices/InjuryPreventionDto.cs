using Rowing.Application.DTOs;
using Rowing.Domain.Entities;

namespace Rowing.Application.InjuryPreventionUseCases;

public class InjuryPreventionDto
{
    public int PreventionId { get; set; }
    public string BodyArea  { get; set; }
    public string InjuryType { get; set; }
    public string PreventionStrategy { get; set; }
    public string StrengtheningExercises { get; set; }
    public StrokePhaseWrapperDto RiskPhase { get; set; }
    public bool IsVerified { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }

    public InjuryPreventionDto(InjuryPrevention model)
    {
        PreventionId = model.Id;
        BodyArea = model.BodyArea;
        InjuryType = model.InjuryType;
        PreventionStrategy = model.PreventionStrategy;
        StrengtheningExercises = model.StrengtheningExercises;
        //risk phase name needs to be set separately 
        IsVerified = model.IsVerified;
        CreatedAt = model.CreatedAt;
        CreatedBy = model.CreatedBy;
    }
    
}