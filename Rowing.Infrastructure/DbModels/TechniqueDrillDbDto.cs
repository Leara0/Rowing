namespace Rowing.Infrastructure.DbModels;

public class TechniqueDrillDbDto
{
    public int drill_id { get; set; }
    public string name { get; set; }
    public string focus_area { get; set; }
    public string description { get; set; }
    public string execution_steps { get; set; }
    public string coaching_points { get; set; }
    public string progression { get; set; }
    public bool is_verified { get; set; }
    public DateTime created_at { get; set; }
    public string created_by { get; set; }
}