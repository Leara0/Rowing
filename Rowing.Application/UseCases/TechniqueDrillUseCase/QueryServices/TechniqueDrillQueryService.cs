using Microsoft.Extensions.Logging;
using Rowing.Application.Exceptions;
using Rowing.Application.Interfaces;
using Rowing.Domain.Entities;

namespace Rowing.Application.DrillTechniqueUseCase.QueryServices;

public class TechniqueDrillQueryService : ITechniqueDrillQueryService
{
    private readonly ITechniqueDrillRepository _drillRepo;
    private readonly ILogger<TechniqueDrillQueryService> _logger;

    public TechniqueDrillQueryService(ITechniqueDrillRepository drillRepo, ILogger<TechniqueDrillQueryService> logger)
    {
        _drillRepo = drillRepo;
        _logger = logger;
    }

    public async Task<IEnumerable<TechniqueDrillDto>> GetAllTechniqueDrillAsync()
    {
        var domainEntities = await _drillRepo.GetAllTechniqueDrillAsync();
        return domainEntities.Select(x => new TechniqueDrillDto(x));
    }

    public async Task<TechniqueDrillDto?> GetTechniqueDrillByIdAsync(int id)
    {
        var domainEntity = await _drillRepo.GetTechniqueDrillByIdAsync(id);
        return domainEntity == null ? null : new TechniqueDrillDto(domainEntity);
    }

    public async Task<IEnumerable<TechniqueDrillDto>> SearchTechniqueDrillAsync(string searchTerm, string searchField)
    {
        IEnumerable<TechniqueDrill> domainEntities;
        //check if searchField is all and if so call general search
        // otherwise call field search
        // map to dto and return
        if (searchField == "All")
            domainEntities = await _drillRepo.SearchAsync(searchTerm);
        else
            domainEntities = await _drillRepo.SearchAsync(searchTerm, searchField);

        return domainEntities.Select(x => new TechniqueDrillDto(x));
    }
}