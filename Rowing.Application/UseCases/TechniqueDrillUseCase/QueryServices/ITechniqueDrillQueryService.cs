namespace Rowing.Application.DrillTechniqueUseCase.QueryServices;

public interface ITechniqueDrillQueryService
{
    public Task<IEnumerable<TechniqueDrillDto>> GetAllTechniqueDrillAsync();
}