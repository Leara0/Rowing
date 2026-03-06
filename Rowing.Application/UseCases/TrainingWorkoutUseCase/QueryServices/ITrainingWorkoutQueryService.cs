namespace Rowing.Application.UseCases.TrainingWorkoutsUseCase.QueryServices;

public interface ITrainingWorkoutQueryService
{
    public Task<IEnumerable<TrainingWorkoutDto>> GetAllTrainingWorkoutAsync();
    public Task<TrainingWorkoutDto?> GetTrainingWorkoutByIdAsync(int id);
    public Task<IEnumerable<TrainingWorkoutDto>> SearchTrainingWorkoutAsync(string searchTerm, string field);

}