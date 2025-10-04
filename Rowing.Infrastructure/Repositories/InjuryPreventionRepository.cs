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

        var preventionDbModel = await conn.QueryAsync<InjuryPreventionDbDto>(sql);
        return preventionDbModel.Select(x => MapToDomain(x));
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

    public async Task UpdateInjuryPreventionAsync(InjuryPrevention model)
    {
        using var conn = _connectionFactory.CreateConnection();
        var sql = @"UPDATE injury_prevention SET body_area = @body_area, injury_type = @injury_type, 
            prevention_strategy = @prevention_strategy, strengthening_exercises = @strengthening_exercises,
            critical_phase_id = @critical_phase_id, is_verified = @is_verified WHERE prevention_id = @id";
        await conn.ExecuteAsync(sql, new
        {
            body_area = model.BodyArea,
            injury_type = model.InjuryType,
            prevention_strategy = model.PreventionStrategy,
            strengthening_exercises = model.StrengtheningExercises,
            critical_phase_id = model.CriticalPhaseId,
            is_verified = model.IsVerified,
            id = model.Id
        });
    }

    public async Task<int> CreateInjuryPreventionAsync(InjuryPrevention model)
    {
        using var conn = _connectionFactory.CreateConnection();
        var sql = @"INSERT INTO injury_prevention (body_area, injury_type, prevention_strategy, strengthening_exercises,
            critical_phase_id, is_verified, created_at, created_by) VALUES (@body_area, @injury_type, 
            @prevention_strategy, @strengthening_exercises,@critical_phase_id, @is_verified, @created_at, @created_by);
            SELECT LAST_INSERT_ID()";
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

    public async Task<int> DeleteInjuryPreventionAsync(int id)
    {
        using var conn = _connectionFactory.CreateConnection();
        var rowsAffected = await conn.ExecuteAsync("DELETE FROM injury_prevention WHERE prevention_id = @id",
            new { id });
        return rowsAffected;
    }

    public InjuryPrevention MapToDomain(InjuryPreventionDbDto model)
    {
        return new InjuryPrevention
        {
            Id = model.prevention_id,
            BodyArea = model.body_area,
            InjuryType = model.injury_type,
            PreventionStrategy = model.prevention_strategy,
            StrengtheningExercises = model.strengthening_exercises,
            CriticalPhaseId = model.critical_phase_id,
            RiskPhaseName = model.risk_phase_name,
            IsVerified = model.is_verified,
            CreatedAt = model.created_at,
            CreatedBy = model.created_by,
        };
    }
}