using System.ComponentModel.DataAnnotations;

namespace Rowing.Application.DrillTechniqueUseCase.CommandServices;

public class UpdateCreateTechniqueDrillDto
{
    [Required] 
    [StringLength(100)] 
    public string Name { get; set; }
    [Required] 
    [StringLength(50)] 
    public string FocusArea { get; set; }
    [Required] 
    public string Description { get; set; }
    [Required] 
    public string ExecutionSteps { get; set; }
    [Required]
    public string CoachingPoints { get; set; }
    [Required]
    public string Progression { get; set; }

}