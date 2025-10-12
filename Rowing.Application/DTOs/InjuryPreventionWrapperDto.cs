namespace Rowing.Application.DTOs;

public class InjuryPreventionWrapperDto
{
    public enum InjuryBodyArea
    {
        Back = 1,
        Knees = 2,
        Wrists = 3,
        Shoulders = 4,
        Ribs = 5,
        Hips = 6
    }
    
    public InjuryBodyArea Selected { get; set; }
    public List<string> Options { get; set; } = Enum.GetNames(typeof(InjuryBodyArea)).ToList();
}