using System.ComponentModel.DataAnnotations;

namespace Rowing.Domain.Entities;

public class CommonErrors
{
    public int ErrorId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int StrokePhaseId { get; set; }
    public string StrokePhaseName { get; set; }
    public string Cause { get; set; }
    public string CorrectiveStrategy { get; set; }
    public string InjuryRisk { get; set; }
    public int RelatedInjuryId { get; set; }
    public string RelatedInjuryName { get; set; }
    public bool IsVerified { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
}