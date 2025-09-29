namespace Rowing.Application.DTOs;

public class StrokePhaseWrapperDto
{
    public enum StrokePhase
    {
        Catch,
        Drive,
        Finish,
        Recovery
    };
    
    public StrokePhase? Selected { get; set; }
    public List<string> Options { get; set; } = Enum.GetNames(typeof(StrokePhase)).ToList();
} 