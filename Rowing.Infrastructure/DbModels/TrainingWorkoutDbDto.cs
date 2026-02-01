namespace Rowing.Infrastructure.DbModels;

public class TrainingWorkoutDbDto
{
    public int workout_id { get; set; }
    public string name { get; set; }
    public string workout_type { get; set; }
    public int duration_minutes { get; set; }
    public string intensity_level { get; set; }
    public string description { get; set; }
    public string target_stroke_rate { get; set; }
    public string training_goal { get; set; }
    public bool is_verified { get; set; }
    public DateTime created_at { get; set; }
    public string created_by { get; set; }
    
}