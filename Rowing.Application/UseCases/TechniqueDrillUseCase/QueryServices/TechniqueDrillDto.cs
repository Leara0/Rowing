using Rowing.Domain.Entities;

namespace Rowing.Application.DrillTechniqueUseCase.QueryServices;

public class TechniqueDrillDto
{
    public int DrillId { get; set; }
    public string Name { get; set; }
    public string FocusArea { get; set; }
    public string Description { get; set; }
    public string ExecutionSteps { get; set; }
    public string CoachingPoints { get; set; }
    public string Progression { get; set; }
    public bool IsVerified { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }

    public TechniqueDrillDto(TechniqueDrill model)
    {
        DrillId = model.DrillId;
        Name = model.Name;
        FocusArea = model.FocusArea;
        Description = model.Description;
        ExecutionSteps = model.ExecutionSteps;
        CoachingPoints = model.CoachingPoints;
        Progression = model.Progression;
        IsVerified = model.IsVerified;
        CreatedAt = model.CreatedAt;
        CreatedBy = model.CreatedBy;
    }

}