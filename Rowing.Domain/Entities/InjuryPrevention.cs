using System.ComponentModel.DataAnnotations;

namespace Rowing.Domain.Entities;

public class InjuryPrevention
{
    public int Id { get; set; }
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
    public int CriticalPhaseId { get; set; }
    [Required]
    public string RiskPhaseName { get; set; }
    [Required]
    public bool IsVerified { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; }
    [Required]
    [StringLength(50)]
    public string CreatedBy { get; set; }
    
    public InjuryPrevention() {}

    public InjuryPrevention(string bodyArea, string injuryType, string prevention, string strengthening)
    {
        BodyArea = bodyArea;
        InjuryType = injuryType;
        PreventionStrategy = prevention;
        StrengtheningExercises = strengthening;
    }
}
