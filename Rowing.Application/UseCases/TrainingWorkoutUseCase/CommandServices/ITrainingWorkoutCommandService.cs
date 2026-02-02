namespace Rowing.Application.UseCases.TrainingWorkoutsUseCase.CommandServices;

public interface ITrainingWorkoutCommandService
{
    public Task UpdateTrainingWorkoutAsync(int id, UpdateCreateTrainingWorkoutDto dto);
    public Task<int> CreateTrainingWorkoutAsync(int id, UpdateCreateTrainingWorkoutDto dto);
    public Task DeleteTrainingWorkoutAsync(int id);
    
}