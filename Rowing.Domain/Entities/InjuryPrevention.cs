using System.ComponentModel.DataAnnotations;

namespace Rowing.Domain.Entities;

public class InjuryPrevention
{
    public int Id { get; set; }
    public string BodyArea { get; private set; }
    public string InjuryType { get; private set; }
    public string PreventionStrategy { get; private set; }
    public string StrengtheningExercises { get; private set; }
    public int CriticalPhaseId { get; private set; }
    public string RiskPhaseName { get; private set; }
    public bool IsVerified { get; set; }
   public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
    
    public InjuryPrevention() {}

    public InjuryPrevention(string bodyArea, string injuryType, string prevention, string strengthening)
    {
        SetBodyArea(bodyArea);
        SetInjuryType(injuryType);
        SetPreventionStrategy(prevention);
        SetStrengtheningExercises(strengthening);
    }

    public void SetBodyArea(string bodyArea)
    {
        if (string.IsNullOrWhiteSpace(bodyArea))
            throw new ArgumentException("Body area is required", nameof(bodyArea));
        if (bodyArea.Length > 50)
            throw new ArgumentException("Body area cannot exceed 50 characters", nameof(bodyArea));
        BodyArea = bodyArea;
    }
    public void SetInjuryType(string injuryType)
    {
        if (string.IsNullOrWhiteSpace(injuryType))
            throw new ArgumentException("Injury type is required", nameof(injuryType));
        if (injuryType.Length > 100)
            throw new ArgumentException("Injury type cannot exceed 100 characters", nameof(injuryType));
        InjuryType = injuryType;
    }
    public void SetPreventionStrategy(string preventionStrategy)
    {
        if (string.IsNullOrWhiteSpace(preventionStrategy))
            throw new ArgumentException("Prevention strategy is required");
        PreventionStrategy = preventionStrategy;
    }
    public void SetStrengtheningExercises(string strengtheningExercises)
    {
        if (string.IsNullOrWhiteSpace(strengtheningExercises))
            throw new ArgumentException("Strengthening exercise is required", nameof(strengtheningExercises));
        StrengtheningExercises = strengtheningExercises;
    }
    public void SetCriticalPhaseId(int phaseId)
    {
        if (phaseId <= 0)
            throw new ArgumentException("Risk Phase ID is required", nameof(phaseId));
        CriticalPhaseId = phaseId;
    }
    public void SetRiskPhaseName(string phaseName)
    {
        if (string.IsNullOrWhiteSpace(phaseName))
            throw new ArgumentException("Risk phase name is required", nameof(phaseName));
        RiskPhaseName = phaseName;
    }

}
