using Dapper;
using Rowing.Application.Interfaces;
using Rowing.Domain.Entities;
using Rowing.Infrastructure.Connection;
using Rowing.Infrastructure.DbModels;

namespace Rowing.Infrastructure.Repositories;

public class TechniqueDrillRepository : ITechniqueDrillRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public TechniqueDrillRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<TechniqueDrill>> GetAllTechniqueDrillAsync()
    {
        using var conn = _connectionFactory.CreateConnection();
        var TechniqueDrillDbModels = await conn.QueryAsync<TechniqueDrillDbDto>
            ("SELECT * FROM technique_drills");
        return TechniqueDrillDbModels.Select(MapToDomain);
    }

    public async Task<TechniqueDrill?> GetTechniqueDrillByIdAsync(int id)
    {
        using var conn = _connectionFactory.CreateConnection();
        var TechniqueDrillDbModel = await conn.QuerySingleOrDefaultAsync<TechniqueDrillDbDto>
            ("SELECT * FROM technique_drills WHERE drill_id = @id", new { id });

        if (TechniqueDrillDbModel == null)
            return null;
        
        return MapToDomain(TechniqueDrillDbModel);
    }

    public async Task<int> UpdateTechniqueDrillAsync(TechniqueDrill model)
    {
        using var conn = _connectionFactory.CreateConnection();
        var sql = @"UPDATE technique_drills SET name = @name, focus_area = @focusArea, description = @description,
            execution_steps = @executionSteps, coaching_points = @coachingPoints, progression = @progression,
            is_verified = @isVerified WHERE drill_id = @id";
        var rowsAffected = await conn.ExecuteAsync(sql, new
        {
            name = model.Name,
            focusArea = model.FocusArea,
            description = model.Description,
            executionSteps = model.ExecutionSteps,
            coachingPoints = model.CoachingPoints,
            progression = model.Progression,
            isVerified = model.IsVerified,
            id = model.DrillId
        });
        return rowsAffected;
    }

    public async Task<int> CreateTechniqueDrillAsync(TechniqueDrill model)
    {
        using var conn = _connectionFactory.CreateConnection();
        var sql = @"INSERT INTO technique_drills (name, focus_area, description, execution_steps, coaching_points, 
            progression, is_verified, created_at, created_by) 
            OUTPUT INSERTED.drill_id
            VALUES (@name, @focusArea, @description, 
            @executionSteps, @coachingPoints, @progression, @isVerified, @createdAt, @createdBy);";

        var newId = await conn.ExecuteScalarAsync<int>(sql, new
        {
            name = model.Name,
            focusArea = model.FocusArea,
            description = model.Description,
            executionSteps = model.ExecutionSteps,
            coachingPoints = model.CoachingPoints,
            progression = model.Progression,
            isVerified = model.IsVerified,
            createdAt = model.CreatedAt,
            createdBy = model.CreatedBy
        });
        return newId;
    }

    public async Task<int> DeleteTechniqueDrillAsync(int id)
    {
        using var conn = _connectionFactory.CreateConnection();
        var rowsAffected = await conn.ExecuteAsync("DELETE FROM technique_drills WHERE drill_id = @id",
            new { id });
        return rowsAffected;
    }

    public TechniqueDrill MapToDomain(TechniqueDrillDbDto model)
    {
        return new TechniqueDrill(model.name, model.focus_area, model.description, model.execution_steps,
            model.coaching_points, model.progression)
        {
            DrillId = model.drill_id,
            CreatedAt = model.created_at,
            CreatedBy = model.created_by,
            IsVerified = model.is_verified
        };
    }
}