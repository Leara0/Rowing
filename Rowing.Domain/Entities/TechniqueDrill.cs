namespace Rowing.Domain.Entities;

public class TechniqueDrill
{
    public string Name { get; private set; }
    public string FocusArea { get; private set; }
    public string Description { get; private set; }
    public string ExecutionSteps { get; private set; }
    public string CoachingPoints { get; private set; }
    public string Progression { get; private set; }
    public bool IsVerified { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }

}