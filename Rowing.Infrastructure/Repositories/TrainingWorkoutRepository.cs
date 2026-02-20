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
        var trainingWorkoutDbModels = await conn.QueryAsync<TrainingWorkoutDbDto>
            ("SELECT * FROM training_workouts");
        return trainingWorkoutDbModels.Select(MapToDomain);
    }

    public async Task<TrainingWorkout?> GetTrainingWorkoutByIdAsync(int id)
    {
        using var conn = _connectionFactory.CreateConnection();
        var trainingWorkoutDbModel = await conn.QuerySingleOrDefaultAsync<TrainingWorkoutDbDto>
            ("SELECT * FROM training_workouts WHERE workout_id = @id", new { id });

        if (trainingWorkoutDbModel == null)
            return null;
        
        return MapToDomain(trainingWorkoutDbModel);
    }

    public async Task<int> UpdateTrainingWorkoutAsync(TrainingWorkout model)
    {
        using var conn = _connectionFactory.CreateConnection();
        var sql = @"UPDATE training_workouts SET name = @name, workout_type = @workoutType, 
                             duration_minutes = @durationMinutes, intensity_level = @intensityLevel, 
                             description = @description, target_stroke_rate = @targetStrokeRate,
                             training_goal = @trainingGoal WHERE workout_id = @id";
        var rowsAffected = await conn.ExecuteAsync(sql, new
        {
            name = model.Name,
            workoutType = model.WorkoutType,
            durationMinutes = model.DurationMinutes,
            intensityLevel = model.IntensityLevel,
            description = model.Description,
            targetStrokeRate = model.TargetStrokeRate,
            trainingGoal = model.TrainingGoal,
            id = model.WorkoutId
        });
        return rowsAffected;
    }
    

    public async Task<int> CreateTrainingWorkoutAsync(TrainingWorkout model)
    {
        using var conn = _connectionFactory.CreateConnection();
        var sql = @"INSERT INTO training_workouts (name, workout_type, duration_minutes, intensity_level, description,
                               target_stroke_rate, training_goal, is_verified, created_at, created_by)
                               OUTPUT INSERTED.workout_id
                               VALUES(@name, @workoutType, @durationMinutes, @intensityLevel, @description,
                               @targetStrokeRate, @trainingGoal, @isVerified, @createdAt, @createdBy)";

        var newId = await conn.ExecuteScalarAsync<int>(sql, new
        {
            name = model.Name,
            workoutType = model.WorkoutType,
            durationMinutes = model.DurationMinutes,
            intensityLevel = model.IntensityLevel,
            description = model.Description,
            targetStrokeRate = model.TargetStrokeRate,
            trainingGoal = model.TrainingGoal,
            isVerified = model.IsVerified,
            createdAt = model.CreatedAt,
            createdBy = model.CreatedBy
        });
        return newId;
    }

    public async Task<int> DeleteTrainingWorkoutAsync(int id)
    {
        using var conn = _connectionFactory.CreateConnection();
        var rowsAffected = await conn.ExecuteAsync("DELETE FROM training_workouts WHERE workout_id = @id",
            new { id });
        return rowsAffected;
    }

    public async Task<IEnumerable<TrainingWorkout?>> SearchAsync(string searchTerm)
    {
        var numericSearch = searchTerm;
        searchTerm = "%" + searchTerm.ToLower() + "%";
        using var conn = _connectionFactory.CreateConnection();
        var sql = @"SELECT * FROM training_workouts WHERE 
                                    LOWER(name) LIKE @searchTerm OR
                                    LOWER(workout_type) LIKE @searchTerm OR
                                    duration_minutes = TRY_CAST(@numericSearch AS INT) OR
                                    LOWER(intensity_level) LIKE @searchTerm OR
                                    LOWER(description) LIKE @searchTerm OR
                                    LOWER(target_stroke_rate) LIKE @searchTerm OR
                                    LOWER(training_goal) LIKE @searchTerm";
        var trainingWorkoutDbModels = await conn.QueryAsync<TrainingWorkoutDbDto>
            (sql, new {searchTerm});
        return trainingWorkoutDbModels.Select(MapToDomain);
    }

    public async Task<IEnumerable<TrainingWorkout?>> SearchAsync(string searchTerm, string fieldName)
    {
        searchTerm = "%" + searchTerm.ToLower() + "%";
        using var conn = _connectionFactory.CreateConnection();

        string sql = fieldName.ToLower() switch
        {
            "name" => "SELECT * FROM training_workouts WHERE LOWER(name) LIKE @searchTerm",
            "description" => "SELECT * FROM training_workouts WHERE LOWER(description) LIKE @searchTerm"
        };
            

        var trainingWorkoutDbModels = await conn.QueryAsync<TrainingWorkoutDbDto>
            (sql, new { searchTerm });
        return trainingWorkoutDbModels.Select(MapToDomain);
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