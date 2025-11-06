using Dapper;
using Rowing.Application.Interfaces;
using Rowing.Domain.Entities;
using Rowing.Infrastructure.Connection;
using Rowing.Infrastructure.DbModels;

namespace Rowing.Infrastructure.Repositories;

public class InjuryPreventionRepository : IInjuryPreventionRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public InjuryPreventionRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<InjuryPrevention>> GetAllInjuryPreventionsAsync()
    {
        using var conn = _connectionFactory.CreateConnection();

        var sql = @"SELECT ip.*, sp.name AS risk_phase_name 
            FROM injury_prevention AS ip 
            INNER JOIN stroke_phases AS sp ON ip.critical_phase_id = sp.phase_id";

        var preventionDbModels = await conn.QueryAsync<InjuryPreventionDbDto>(sql);
        return preventionDbModels.Select(MapToDomain);
    }

    public async Task<InjuryPrevention?> GetInjuryPreventionByIdAsync(int id)
    {
        using var conn = _connectionFactory.CreateConnection();

        var sql = @"SELECT ip.*, sp.name AS risk_phase_name
            FROM injury_prevention AS ip
            INNER JOIN stroke_phases AS sp ON ip.critical_phase_id = sp.phase_id
            WHERE ip.prevention_id = @id";

        var preventionDbModel = await conn.QuerySingleOrDefaultAsync<InjuryPreventionDbDto>(sql, new { id });
        return preventionDbModel == null? null : MapToDomain(preventionDbModel);
    }

    public async Task<int> UpdateInjuryPreventionAsync(InjuryPrevention model)
    {
        using var conn = _connectionFactory.CreateConnection();
        var sql = @"UPDATE injury_prevention SET body_area = @body_area, injury_type = @injury_type, 
            prevention_strategy = @prevention_strategy, strengthening_exercises = @strengthening_exercises,
            critical_phase_id = @critical_phase_id, is_verified = @is_verified WHERE prevention_id = @id";
        var rowsAffected = await conn.ExecuteAsync(sql, new
        {
            body_area = model.BodyArea,
            injury_type = model.InjuryType,
            prevention_strategy = model.PreventionStrategy,
            strengthening_exercises = model.StrengtheningExercises,
            critical_phase_id = model.CriticalPhaseId,
            is_verified = model.IsVerified,
            id = model.Id
        });
        return rowsAffected;
    }

    public async Task<int> CreateInjuryPreventionAsync(InjuryPrevention model)
    {
        using var conn = _connectionFactory.CreateConnection();
        var sql = @"INSERT INTO injury_prevention (body_area, injury_type, prevention_strategy, strengthening_exercises,
            critical_phase_id, is_verified, created_at, created_by) 
            OUTPUT INSERTED.prevention_id
            VALUES (@body_area, @injury_type, 
            @prevention_strategy, @strengthening_exercises,@critical_phase_id, @is_verified, @created_at, @created_by);";
        var newId = await conn.ExecuteScalarAsync<int>(sql, new
        {
            body_area = model.BodyArea,
            injury_type = model.InjuryType,
            prevention_strategy = model.PreventionStrategy,
            strengthening_exercises = model.StrengtheningExercises,
            critical_phase_id = model.CriticalPhaseId,
            is_verified = model.IsVerified,
            created_at = model.CreatedAt,
            created_by = model.CreatedBy
        });
        return newId ;
    }

    public async Task<bool> HasDependentRecordsAsync(int injuryId)
    {
        using var conn = _connectionFactory.CreateConnection();
        var sql = "SELECT COUNT(*) FROM common_errors WHERE related_injury_id = @id";
        var count = await conn.QuerySingleAsync<int>(sql, new { id = injuryId });
        return count > 0;
    }
    
    public async Task<int> DeleteInjuryPreventionAsync(int id)
    {
        using var conn = _connectionFactory.CreateConnection();
        var rowsAffected = await conn.ExecuteAsync("DELETE FROM injury_prevention WHERE prevention_id = @id",
            new { id });
        return rowsAffected;
    }

    public InjuryPrevention MapToDomain(InjuryPreventionDbDto model)
    {
        return new InjuryPrevention(model.body_area, model.injury_type, model.prevention_strategy, 
            model.strengthening_exercises, model.critical_phase_id, model.risk_phase_name)
        {
            Id = model.prevention_id,
            IsVerified = model.is_verified,
            CreatedAt = model.created_at,
            CreatedBy = model.created_by,
        };
    }
}