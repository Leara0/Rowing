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

    public TechniqueDrill(string name, string focusArea, string description, string executionSteps,
        string coachingPoints, string progression)
    {
        SetName(name);
        SetFocusArea(focusArea);
        SetDescription(description);
        SetExecutionSteps(executionSteps);
        SetCoachingPoints(coachingPoints);
        SetProgression(progression);
    }

    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required", nameof(name));
        if (name.Length > 100)
            throw new ArgumentException("Name cannot exceed 100 characters", nameof(name));
        Name = name;
    }

    public void SetFocusArea(string focusArea)
    {
        if (string.IsNullOrWhiteSpace(focusArea))
            throw new ArgumentException("Focus area is required", nameof(focusArea));
        if (focusArea.Length > 50)
            throw new ArgumentException("Focus area cannot exceed 50 characters", nameof(focusArea));
        FocusArea = focusArea;
    }

    public void SetDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description is required", nameof(description));
        Description = description;
    }

    public void SetExecutionSteps(string executionSteps)
    {
        if (string.IsNullOrWhiteSpace(executionSteps))
            throw new ArgumentException("Execution steps is required", nameof(executionSteps));
        ExecutionSteps = executionSteps;
    }

    public void SetCoachingPoints(string coachingPoints)
    {
        if (string.IsNullOrWhiteSpace(coachingPoints))
            throw new ArgumentException("Coaching points is required", nameof(coachingPoints));
        CoachingPoints = coachingPoints;
    }

    public void SetProgression(string progression)
    {
        if (string.IsNullOrWhiteSpace(progression))
            throw new ArgumentException("Progression is required", nameof(progression));
        Progression = progression;
    }
}