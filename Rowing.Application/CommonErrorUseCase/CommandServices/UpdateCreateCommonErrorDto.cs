using System.ComponentModel.DataAnnotations;
using Rowing.Application.DTOs;

namespace Rowing.Application.CommonErrors.CommandServices;

public class UpdateCreateCommonErrorDto
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; }
    [Required] 
    public string Description { get; set; }
    [Required]
    public StrokePhaseWrapperDto RiskPhase { get; set; }
    [Required]
    public string Cause { get; set; }
    [Required]
    public string CorrectionStrategy { get; set; }
    [Required]
    public InjuryPreventionWrapperDto RelatedInjuryBodyArea { get; set; }
}