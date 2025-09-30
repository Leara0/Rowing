using System.ComponentModel.DataAnnotations;
using Rowing.Application.DTOs;
using Rowing.Domain.Entities;

namespace Rowing.Application.InjuryPreventionUseCases;

public class UpdateInjuryPrevRequestDto
{
    public string BodyArea { get; set; }
    public string InjuryType { get; set; }
    public string PreventionStrategy { get; set; }
    public string StrengtheningExercises { get; set; }
    public StrokePhaseWrapperDto RiskPhase { get; set; }

    public UpdateInjuryPrevRequestDto() { }

    public UpdateInjuryPrevRequestDto(InjuryPrevention model)
    {
        BodyArea = model.BodyArea;
        InjuryType = model.InjuryType;
        PreventionStrategy = model.PreventionStrategy;
        StrengtheningExercises = model.StrengtheningExercises;
    }
}