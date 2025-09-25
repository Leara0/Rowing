namespace Rowing.Infrastructure.DbModels;

public class InjuryPreventionDbDto
{
    public int prevention_id { get; set; }
    public string body_area { get; set; }
    public string injury_type { get; set; }
    public string prevention_strategy { get; set; }
    public string strengthening_exercises { get; set; }
    public string risk_phase_name { get; set; }
    public bool is_verified { get; set; }
    public DateTime created_at { get; set; }
    public string created_by { get; set; }

}