namespace Rowing.Application.DrillTechniqueUseCase.CommandServices;

public interface ITechniqueDrillCommandService
{
    public Task UpdateTechniqueDrillAsync(int id, UpdateCreateTechniqueDrillDto dto);
    public Task<int> CreateTechniqueDrillAsync(UpdateCreateTechniqueDrillDto dto);

}