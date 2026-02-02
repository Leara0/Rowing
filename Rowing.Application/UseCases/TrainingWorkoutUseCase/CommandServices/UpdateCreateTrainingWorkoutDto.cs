using System.ComponentModel.DataAnnotations;

namespace Rowing.Application.UseCases.TrainingWorkoutsUseCase.CommandServices;

public class UpdateCreateTrainingWorkoutDto
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; }
    [Required]
    [StringLength(50)]
    public string WorkoutType { get; set; }
    [Required]
    public int DurationMinutes { get; set; }
    [Required]
    [StringLength(20)]
    public string IntensityLevel { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    [StringLength(50)]
    public string TargetStrokeRate { get; set; }
    [Required]
    public string TrainingGoal { get; set; }
}