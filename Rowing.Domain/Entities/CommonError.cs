using System.ComponentModel.DataAnnotations;

namespace Rowing.Domain.Entities;

public class CommonError
{
    //use private setters to enforce required fields via set methods
    public int ErrorId { get; set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int StrokePhaseId { get; private set; }
    public string StrokePhaseName { get; private set; }
    public string Cause { get; private set; }
    public string CorrectionStrategy { get; private set; }
    public int RelatedInjuryId { get; private set; }
    public string RelatedInjuryBodyArea { get; private set; }
    public bool IsVerified { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }

    public CommonError(string name, string desc, string cause, string strategy)
    {
        SetName(name);
        SetDescription(desc);
        SetCause(cause);
        SetCorrectionStrategy(strategy);
    }
    
    public CommonError(string name, string desc, int phaseId, string phaseName, string cause, string strategy,
        int relatedId, string relatedName)
    {
        SetName(name);
        SetDescription(desc);
        SetStrokePhaseId(phaseId);
        SetStrokePhaseName(phaseName);
        SetCause(cause);
        SetCorrectionStrategy(strategy);
        SetRelatedInjuryId(relatedId);
        SetRelatedInjuryBodyArea(relatedName);
    }

    public CommonError() { }

    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required", nameof(name));
        if (name.Length > 100)
            throw new ArgumentException("Name cannot exceed 100 characters", nameof(name));
        Name = name;
    }
    public void SetDescription(string desc)
    {
        if (string.IsNullOrWhiteSpace(desc))
            throw new ArgumentException("Description is required", nameof(desc));
        Description = desc;
    }
    public void SetStrokePhaseId(int id)
    {
        if (id <= 0)
            throw new ArgumentException("Stroke phase ID is required", nameof(id));
        StrokePhaseId = id;
    }
    public void SetStrokePhaseName(string phaseName)
    {
        if (string.IsNullOrWhiteSpace(phaseName))
            throw new ArgumentException("Stroke phase name  is required", nameof(phaseName));
        StrokePhaseName = phaseName;
    }
    public void SetCause(string cause)
    {
        if (string.IsNullOrWhiteSpace(cause))
            throw new ArgumentException("Cause  is required", nameof(cause));
        Cause = cause;
    }
    public void SetCorrectionStrategy(string strategy)
    {
        if (string.IsNullOrWhiteSpace(strategy))
            throw new ArgumentException("Corrective strategy is required", nameof(strategy));
        CorrectionStrategy = strategy;
    }
    public void SetRelatedInjuryId(int id)
    {
        if (id <= 0)
            throw new ArgumentException("Related Injury ID is required", nameof(id));
        RelatedInjuryId = id;
    }
    public void SetRelatedInjuryBodyArea(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Related injury name is required", nameof(name));
        RelatedInjuryBodyArea = name;
    }
}