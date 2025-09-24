using System.ComponentModel.DataAnnotations;

namespace Rowing.Domain.Entities;

public class InjuryPrevention
{
    public int Id { get; init; }
    [Required]
    [StringLength(50)]
    public string BodyArea { get; set; }
    [Required]
    [StringLength(100)]
    public string InjuryType { get; set; }
    [Required]
    public string PreventionStrategy { get; set; }
    public string StrengtheningExercises { get; set; }
    public string RiskPhaseName { get; set; }
    public bool IsVerified { get; set; }
    public DateTime CreatedAt { get; set; }
    [StringLength(50)]
    public string CreatedBy { get; set; }
    
    public InjuryPrevention() {}

    public InjuryPrevention(string bodyArea, string injuryType, string prevention, string strengthening,
        string riskPhase)
    {
        BodyArea = bodyArea;
        InjuryType = injuryType;
        PreventionStrategy = prevention;
        StrengtheningExercises = strengthening;
        RiskPhaseName = riskPhase;
    }
}
