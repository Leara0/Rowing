using Microsoft.Extensions.Logging;
using Rowing.Application.Exceptions;
using Rowing.Application.Interfaces;
using Rowing.Application.UseCases.TrainingWorkoutsUseCase.QueryServices;
using Rowing.Domain.Entities;

namespace Rowing.Application.UseCases.TrainingWorkoutsUseCase.CommandServices;

public class TrainingWorkoutCommandService : ITrainingWorkoutCommandService
{
    private readonly ITrainingWorkoutRepository _trainingRepo;
    private readonly ILogger<TrainingWorkoutCommandService> _logger;

    public TrainingWorkoutCommandService(ITrainingWorkoutRepository repo,
        ILogger<TrainingWorkoutCommandService> logger)
    {
        _trainingRepo = repo;
        _logger = logger;
    }


    public async Task UpdateTrainingWorkoutAsync(int id, UpdateCreateTrainingWorkoutDto dto)
    {
        var domainEntity = new TrainingWorkout(dto.Name, dto.WorkoutType, dto.DurationMinutes, dto.IntensityLevel,
            dto.Description, dto.TargetStrokeRate, dto.TrainingGoal);
        domainEntity.IsVerified = false;
        domainEntity.WorkoutId = id;

        var rowsAffected = await _trainingRepo.UpdateTrainingWorkoutAsync(domainEntity);

        if (rowsAffected != 1)
        {
            _logger.LogError("Invalid training workout id {id}. No records were updated", id);
            throw new NotFoundException($"Training workout record with id {id} not found");

        }
    }

    
    public async Task<int> CreateTrainingWorkoutAsync(UpdateCreateTrainingWorkoutDto dto)
    {
        var domainEntity = new TrainingWorkout(dto.Name, dto.WorkoutType, dto.DurationMinutes, dto.IntensityLevel,
            dto.Description, dto.TargetStrokeRate, dto.TrainingGoal);
        domainEntity.IsVerified = false;
        domainEntity.CreatedAt = DateTime.UtcNow;
        domainEntity.CreatedBy = "user";

        return await _trainingRepo.CreateTrainingWorkoutAsync(domainEntity);

    }

    public async Task DeleteTrainingWorkoutAsync(int id)
    {
        var rowsAffected = await _trainingRepo.DeleteTrainingWorkoutAsync(id);

        if (rowsAffected != 1)
        {
            _logger.LogError("Invalid training workout id {id}. No records were deleted.", id);
            throw new NotFoundException($"Training workout record with id {id} not found");
        }
    }
}