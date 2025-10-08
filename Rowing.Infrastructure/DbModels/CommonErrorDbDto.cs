namespace Rowing.Infrastructure.DbModels;

public class CommonErrorDbDto
{
    public int error_id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public int phase_id { get; set; }
    public string phase_name { get; set; }
    public string cause { get; set; }
    public string correction_strategy { get; set; }
    public int related_injury_id { get; set; }
    public string related_injury_body_area { get; set; }
    public bool is_verified { get; set; }
    public DateTime created_at { get; set; }
    public string created_by { get; set; }
}