using Rowing.Domain.Entities;

namespace Rowing.Application.Interfaces;

public interface ITrainingWorkoutRepository
{
    public Task<IEnumerable<TrainingWorkout>> GetAllTrainingWorkoutAsync();

    public Task<TrainingWorkout?> GetTrainingWorkoutByIdAsync(int id);
    public Task<int> UpdateTrainingWorkoutAsync(TrainingWorkout model);
    public Task<int> CreateTrainingWorkoutAsync(TrainingWorkout model);
    public Task<int> DeleteTrainingWorkoutAsync(int id);

}