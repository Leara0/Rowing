namespace Rowing.Application.StrokePhase;
using Rowing.Domain.Entities;
using System.Text.Json.Serialization;

public class StrokePhaseDto
{
    [JsonPropertyName("phase_id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("key_focus")]
    public string KeyFocus { get; set; }
    
    // Parameterless constructor for deserialization
    public StrokePhaseDto() { }

    public StrokePhaseDto(StrokePhase model)
    {
        Id = model.Id;
        Name = model.Name;
        KeyFocus = model.KeyFocus;
    }
}