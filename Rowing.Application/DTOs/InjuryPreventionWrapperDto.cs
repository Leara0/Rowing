namespace Rowing.Application.DTOs;

public class InjuryPreventionWrapperDto
{
    public enum InjuryBodyArea
    {
        Back,
        Knees,
        Wrists,
        Shoulders,
        Ribs,
        Hips
    }
    
    public InjuryBodyArea Selected { get; set; }
    public List<string> Options { get; set; } = Enum.GetNames(typeof(InjuryBodyArea)).ToList();
}