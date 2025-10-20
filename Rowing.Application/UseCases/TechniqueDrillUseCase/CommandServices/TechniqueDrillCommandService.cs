using Microsoft.Extensions.Logging;
using Rowing.Application.Exceptions;
using Rowing.Application.Interfaces;
using Rowing.Domain.Entities;

namespace Rowing.Application.DrillTechniqueUseCase.CommandServices;

public class TechniqueDrillCommandService : ITechniqueDrillCommandService
{
    private readonly ITechniqueDrillRepository _drillRepo;
    private readonly ILogger<TechniqueDrillCommandService> _logger;

    public TechniqueDrillCommandService(ITechniqueDrillRepository drillRepo,
        ILogger<TechniqueDrillCommandService> logger)
    {
        _drillRepo = drillRepo;
        _logger = logger;
    }

    public async Task UpdateTechniqueDrillAsync(int id, UpdateCreateTechniqueDrillDto dto)
    {
        var domainEntity = new TechniqueDrill(dto.Name, dto.FocusArea, dto.Description, dto.ExecutionSteps,
            dto.CoachingPoints, dto.Progression);
        domainEntity.DrillId = id;
        domainEntity.IsVerified = false;

        var rowsAffected = await _drillRepo.UpdateTechniqueDrillAsync(domainEntity);

        if (rowsAffected != 1)
        {
            _logger.LogError("Invalid technique drill id {id}. No records were updated", id);
            throw new NotFoundException($"Technique drill record with id {id} not found");
        }
    }

    public async Task<int> CreateTechniqueDrillAsync(UpdateCreateTechniqueDrillDto dto)
    {
        var domainEntity = new TechniqueDrill(dto.Name, dto.FocusArea, dto.Description, dto.ExecutionSteps,
            dto.CoachingPoints, dto.Progression);
        domainEntity.IsVerified = false;
        domainEntity.CreatedAt = DateTime.UtcNow;
        domainEntity.CreatedBy = "user";

        return await _drillRepo.CreateTechniqueDrillAsync(domainEntity);
    }
}