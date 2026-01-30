namespace Rowing.Domain.Entities;

public class TrainingWorkout
{
    public int WorkoutId { get; set; }
    public string Name { get; private set; }
    public string WorkoutType { get; private set; }
    public int DurationMinutes { get; private set; }
    public string IntensityLevel { get; private set; }
    public string Description { get; private set; }
    public string TargetStrokeRate { get; private set; }
    public string TrainingGoal { get; private set; }
    public bool IsVerified { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }

    public TrainingWorkout(string name, string workoutType, int duration, string intensity, string description,
        string targetStroke, string goal)
    {
        SetName(name);
        SetWorkoutType(workoutType);
        SetDurationMinutes(duration);
        SetIntensityLevel(intensity);
        SetDescription(description);
        SetTargetStrokeRate(targetStroke);
        SetTrainingGoal(goal);
    }

    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required", nameof(name));
        if (name.Length > 100)
            throw new ArgumentException("Name cannot exceed 100 characters", nameof(name));
        Name = name;
    }

    public void SetWorkoutType(string workoutType)
    {
        if (string.IsNullOrWhiteSpace(workoutType))
            throw new ArgumentException("Workout type is required", nameof(workoutType));
        if (workoutType.Length > 50)
            throw new ArgumentException("Workout type cannot exceed 50 characters", nameof(workoutType));
        WorkoutType = workoutType;
    }

    public void SetDurationMinutes(int duration)
    {
        if (duration <= 0)
            throw new ArgumentException("Duration minutes are required", nameof(duration));
        DurationMinutes = duration;
    }

    public void SetIntensityLevel(string intensity)
    {
        if (string.IsNullOrWhiteSpace(intensity))
            throw new ArgumentException("Intensity level is required", nameof(intensity));
        if (intensity.Length > 20)
            throw new ArgumentException("Intensity level cannot exceed 20 characters", nameof(intensity));
        IntensityLevel = intensity;
    }
    
    public void SetDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description is required", nameof(description));
        Description = description;
    }
    
    public void SetTargetStrokeRate(string strokeRate)
    {
        if (string.IsNullOrWhiteSpace(strokeRate))
            throw new ArgumentException("Target stroke rate is required", nameof(strokeRate));
        if (strokeRate.Length > 50)
            throw new ArgumentException("Target stroke rate cannot exceed 50 characters", nameof(strokeRate));
        TargetStrokeRate = strokeRate;
    }
    
    public void SetTrainingGoal(string goal)
    {
        if (string.IsNullOrWhiteSpace(goal))
            throw new ArgumentException("Training goal is required", nameof(goal));
        TrainingGoal = goal;
    }
    

    
}