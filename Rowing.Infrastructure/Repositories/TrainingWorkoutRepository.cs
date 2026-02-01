using Dapper;
using Rowing.Application.Interfaces;
using Rowing.Domain.Entities;
using Rowing.Infrastructure.Connection;
using Rowing.Infrastructure.DbModels;

namespace Rowing.Infrastructure.Repositories;

public class TrainingWorkoutRepository : ITrainingWorkoutRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public TrainingWorkoutRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<TrainingWorkout>> GetAllTrainingWorkoutAsync()
    {
        using var conn = _connectionFactory.CreateConnection();
        var techniqueDrillDbModels = await conn.QueryAsync<TrainingWorkoutDbDto>
            ("SELECT * FROM training_workouts");
        return techniqueDrillDbModels.Select(MapToDomain);
    }

    public Task<TrainingWorkout?> GetTrainingWorkoutByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateTrainingWorkoutAsync(TrainingWorkout model)
    {
        throw new NotImplementedException();
    }

    public Task<int> CreateTrainingWorkoutAsync(TrainingWorkout model)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteTrainingWorkoutAsync(int id)
    {
        throw new NotImplementedException();
    }


    public TrainingWorkout MapToDomain(TrainingWorkoutDbDto model)
    {
        return new TrainingWorkout(model.name, model.workout_type, model.duration_minutes, model.intensity_level,
            model.description, model.target_stroke_rate, model.training_goal)
        {
            WorkoutId = model.workout_id,
            IsVerified = model.is_verified,
            CreatedAt = model.created_at,
            CreatedBy = model.created_by
        };
    }

}