using System.ComponentModel.DataAnnotations;
using Rowing.Application.DTOs;

namespace Rowing.Application.InjuryPreventionUseCases;

public class UpdateInjuryPrevRequestDto
{
    [Required]
    [StringLength(50)]
    public string BodyArea { get; set; }
    [Required]
    [StringLength(100)]
    public string InjuryType { get; set; }
    [Required]
    public string PreventionStrategy { get; set; }
    [Required]
    public string StrengtheningExercises { get; set; }
    [Required]
    public StrokePhaseWrapperDto RiskPhase { get; set; }

   
}