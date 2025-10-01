using System.ComponentModel.DataAnnotations;
using Rowing.Application.DTOs;
using Rowing.Domain.Entities;

namespace Rowing.Application.InjuryPreventionUseCases;

public class UpdateInjuryPrevResponseDto
{
    public string BodyArea { get; set; }
    public string InjuryType { get; set; }
    public string PreventionStrategy { get; set; }
    public string StrengtheningExercises { get; set; }
    public StrokePhaseWrapperDto RiskPhase { get; set; }

    public UpdateInjuryPrevResponseDto() { }

    public UpdateInjuryPrevResponseDto(InjuryPrevention model)
    {
        BodyArea = model.BodyArea;
        InjuryType = model.InjuryType;
        PreventionStrategy = model.PreventionStrategy;
        StrengtheningExercises = model.StrengtheningExercises;
    }
}