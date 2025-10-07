namespace Rowing.Application.DTOs;

public class StrokePhaseWrapperDto
{
    public enum StrokePhase
    {
        Catch = 1,
        Drive = 2,
        Finish = 3,
        Recovery = 4
    };
    
    public StrokePhase Selected { get; set; }
    public List<string> Options { get; set; } = Enum.GetNames(typeof(StrokePhase)).ToList();
} 