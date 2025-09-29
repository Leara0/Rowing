using System.ComponentModel.DataAnnotations;
using Rowing.Application.DTOs;
using Rowing.Domain.Entities;

namespace Rowing.Application.InjuryPreventionUseCases;

public class UpdateInjuryPreventionDto
{
    [Required]
    [StringLength(50)]
    public string BodyArea { get; set; }
    [Required]
    [StringLength(100)]
    public string InjuryType { get; set; }
    [Required]
    public string PreventionStrategy { get; set; }
    public string StrengtheningExercises { get; set; }
    public StrokePhaseWrapperDto RiskPhase { get; set; }

    public UpdateInjuryPreventionDto() { }

    public UpdateInjuryPreventionDto(InjuryPrevention model)
    {
        BodyArea = model.BodyArea;
        InjuryType = model.InjuryType;
        PreventionStrategy = model.PreventionStrategy;
        StrengtheningExercises = model.StrengtheningExercises;
    }
}