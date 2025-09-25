namespace Rowing.Application.InjuryPreventionUseCases;

public class InjuryPreventionDto
{
    public int PreventionId { get; set; }
    public string BodyArea  { get; set; }
    public string InjuryType { get; set; }
    public string PreventionStrategy { get; set; }
    public string StrengtheningExercises { get; set; }
    public string RiskPhaseName { get; set; }
    public bool IsVerified { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
}