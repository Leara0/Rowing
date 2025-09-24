namespace Rowing.Application.StrokePhase;
using Rowing.Domain.Entities;

public class StrokePhaseDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string KeyFocus { get; init; }
    
    public StrokePhaseDto(StrokePhase model)
    {
        Id = model.Id;
        Name = model.Name;
        KeyFocus = model.KeyFocus;
    }
}