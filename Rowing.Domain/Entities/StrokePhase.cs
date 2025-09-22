namespace Rowing.Domain.Entities;

public class StrokePhase
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string KeyFocus { get; set; }
}