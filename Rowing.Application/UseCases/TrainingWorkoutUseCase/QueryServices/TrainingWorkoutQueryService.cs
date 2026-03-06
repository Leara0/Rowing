using Microsoft.Extensions.Logging;
using Rowing.Application.Interfaces;
using Rowing.Domain.Entities;


namespace Rowing.Application.UseCases.TrainingWorkoutsUseCase.QueryServices;

public class TrainingWorkoutQueryService : ITrainingWorkoutQueryService
{
    private readonly ITrainingWorkoutRepository _trainingRepo;
    private readonly ILogger<TrainingWorkoutQueryService> _logger;

    public TrainingWorkoutQueryService(ITrainingWorkoutRepository repo, ILogger<TrainingWorkoutQueryService> logger)
    {
        _trainingRepo = repo;
        _logger = logger;
    }
    

    public async Task<IEnumerable<TrainingWorkoutDto>> GetAllTrainingWorkoutAsync()
    {
        var domainEntities = await _trainingRepo.GetAllTrainingWorkoutAsync();
        return domainEntities.Select(x => new TrainingWorkoutDto(x));
    }

    public async Task<TrainingWorkoutDto?> GetTrainingWorkoutByIdAsync(int id)
    {
        var domainEntity = await _trainingRepo.GetTrainingWorkoutByIdAsync(id);
        return domainEntity == null ? null : new TrainingWorkoutDto(domainEntity);
    }

    public async Task<IEnumerable<TrainingWorkoutDto>> SearchTrainingWorkoutAsync(string searchTerm, string field)
    {
        IEnumerable<TrainingWorkout> domainEntities;

        if (field == "All")
            domainEntities = await _trainingRepo.SearchAsync(searchTerm);
        else
            domainEntities = await _trainingRepo.SearchAsync(searchTerm, field);

        return domainEntities.Select(x => new TrainingWorkoutDto(x));

    }
}