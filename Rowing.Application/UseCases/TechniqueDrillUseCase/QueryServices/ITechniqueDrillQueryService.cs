namespace Rowing.Application.DrillTechniqueUseCase.QueryServices;

public interface ITechniqueDrillQueryService
{
    public Task<IEnumerable<TechniqueDrillDto>> GetAllTechniqueDrillAsync();
    public Task<TechniqueDrillDto?> GetTechniqueDrillByIdAsync(int id);
    public Task<IEnumerable<TechniqueDrillDto>> SearchTechniqueDrillAsync(string searchTerm, string searchField);
}