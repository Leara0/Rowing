using Dapper;
using Mysqlx.Prepare;
using Rowing.Application.Interfaces;
using Rowing.Domain.Entities;
using Rowing.Infrastructure.Connection;
using Rowing.Infrastructure.DbModels;

namespace Rowing.Infrastructure.Repositories;

public class StrokePhaseRepository : IStrokePhaseRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public StrokePhaseRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<StrokePhase>> GetAllStrokePhasesAsync()
    {
        //here is where we create a new connection for one time use
        using var conn = _connectionFactory.CreateConnection();

        var resultsDbModels = await conn
            .QueryAsync<StrokePhaseDbDto>("SELECT * FROM stroke_phases");
        return resultsDbModels.Select(x => MapToDomain(x));
    }

    public async Task<StrokePhase?> GetStrokePhaseByIdAsync(int id)
    {
        using var conn = _connectionFactory.CreateConnection();
        var resultDbModel = await conn
            .QuerySingleOrDefaultAsync<StrokePhaseDbDto>
                ("SELECT * FROM stroke_phases WHERE phase_id = @id", new { id });

        if (resultDbModel == null)
            return null;
        
        return MapToDomain(resultDbModel);
    }

    public async Task<int> UpdateKeyFocusAsync(int id, string keyFocus)
    {
        //open connection
        using var conn = _connectionFactory.CreateConnection();
        //update key focus
        var rowsAffected = await conn.ExecuteAsync(
            "UPDATE stroke_phases SET key_focus = @keyFocus WHERE phase_id = @id",
            new { id, keyFocus });
        return rowsAffected;

    }

    //helper mapping method from Db model to domain entity
    private StrokePhase MapToDomain(StrokePhaseDbDto model)
    {
        var domainEntity =  new StrokePhase
        {
            Id = model.phase_id,
            Name = model.name,
        };
        domainEntity.SetKeyFocus(model.key_focus);
        return domainEntity; 
    }
}