namespace Rowing.Domain.Entities;

public class StrokePhase
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string KeyFocus { get; private set; }

    public void SetKeyFocus(string focus)
    {
        if (string.IsNullOrWhiteSpace(focus))
            throw new ArgumentException("Key Focus is required", nameof(focus));
        KeyFocus = focus;
    }
}