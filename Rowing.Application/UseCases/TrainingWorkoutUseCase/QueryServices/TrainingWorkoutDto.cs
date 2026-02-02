using Rowing.Domain.Entities;

namespace Rowing.Application.UseCases.TrainingWorkoutsUseCase.QueryServices;

public class TrainingWorkoutDto
{
    public int WorkoutId { get; set; }
    public string Name { get; set; }
    public string WorkoutType { get; set; }
    public int DurationMinutes { get; set; }
    public string IntensityLevel { get; set; }
    public string Description { get; set; }
    public string TargetStrokeRate { get; set; }
    public string TrainingGoal { get; set; }
    public bool IsVerified { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }

    public TrainingWorkoutDto(TrainingWorkout model)
    {
        WorkoutId = model.WorkoutId;
        Name = model.Name;
        WorkoutType = model.WorkoutType;
        DurationMinutes = model.DurationMinutes;
        IntensityLevel = model.IntensityLevel;
        Description = model.Description;
        TargetStrokeRate = model.TargetStrokeRate;
        TrainingGoal = model.TrainingGoal;
        IsVerified = model.IsVerified;
        CreatedAt = model.CreatedAt;
        CreatedBy = model.CreatedBy;
    }
}