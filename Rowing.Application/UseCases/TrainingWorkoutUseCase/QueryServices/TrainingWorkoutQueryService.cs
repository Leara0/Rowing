using Microsoft.Extensions.Logging;
using Rowing.Application.Interfaces;


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

    public Task<TrainingWorkoutDto?> GetTrainingWorkoutByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}