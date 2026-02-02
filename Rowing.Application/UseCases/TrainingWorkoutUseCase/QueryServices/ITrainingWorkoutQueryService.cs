namespace Rowing.Application.UseCases.TrainingWorkoutsUseCase.QueryServices;

public interface ITrainingWorkoutQueryService
{
    public Task<IEnumerable<TrainingWorkoutDto>> GetAllTrainingWorkoutAsync();
    public Task<TrainingWorkoutDto?> GetTrainingWorkoutByIdAsync(int id);

}