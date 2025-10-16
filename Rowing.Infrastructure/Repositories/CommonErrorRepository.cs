using Dapper;
using Rowing.Application.Interfaces;
using Rowing.Domain.Entities;
using Rowing.Infrastructure.Connection;
using Rowing.Infrastructure.DbModels;

namespace Rowing.Infrastructure.Repositories;

public class CommonErrorRepository : ICommonErrorRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public CommonErrorRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory; 
    }

    public async Task<IEnumerable<CommonError>> GetAllCommonErrorsAsync()
    {
        using var conn = _connectionFactory.CreateConnection();
        var sql = @"SELECT ce.*, sp.name AS phase_name, ip.body_area AS related_injury_body_area 
            FROM common_errors AS ce
            INNER JOIN stroke_phases as sp ON ce.phase_id = sp.phase_id
            INNER JOIN injury_prevention as ip ON ce.related_injury_id = ip.prevention_id";
        
        var commonErrorsDbModel = await conn.QueryAsync<CommonErrorDbDto>(sql);
        return commonErrorsDbModel.Select(MapToDomain);
    }

    public async Task<CommonError?> GetCommonErrorByIdAsync(int id)
    {
        using var conn = _connectionFactory.CreateConnection();
        var sql = @"SELECT ce.*, sp.name AS phase_name, ip.body_area AS related_injury_body_area
            FROM common_errors as ce
            INNER JOIN stroke_phases AS sp ON ce.phase_id = sp.phase_id
            INNER JOIN injury_prevention AS ip ON ce.related_injury_id = ip.prevention_id
            WHERE ce.error_id = @id";
        var commonErrorDbModel = await conn.QuerySingleOrDefaultAsync<CommonErrorDbDto>(sql, new { id });
        return commonErrorDbModel == null ? null : MapToDomain(commonErrorDbModel);
    }

    public async Task<int> UpdateCommonErrorAsync(CommonError model)
    {
        using var conn = _connectionFactory.CreateConnection();
        var sql = @"UPDATE common_errors SET name = @name, description = @description, phase_id = @phase_id,
            cause = @cause, correction_strategy = @strategy, related_injury_id = @relatedId, is_verified = @verified
            WHERE error_id = @id";
        var rowsAffected = await conn.ExecuteAsync(sql, new
        {
            name = model.Name,
            description = model.Description,
            phase_id = model.StrokePhaseId,
            cause = model.Cause,
            strategy = model.CorrectionStrategy,
            relatedId = model.RelatedInjuryId,
            verified = model.IsVerified,
            id = model.ErrorId
        });

        return rowsAffected;
    }

    public async Task<int> CreateCommonErrorsAsync(CommonError model)
    {
        using var conn = _connectionFactory.CreateConnection();
        var sql = @"INSERT INTO common_errors (name, description, phase_id, cause, correction_strategy,
            related_injury_id, is_verified, created_at, created_by) VALUES (@name, @description, @phaseId, @cause, @correctionStrategy,
            @relatedInjuryId, @isVerified, @createdAt, @createdBy);
            SELECT LAST_INSERT_ID()";
        var newId = await conn.ExecuteScalarAsync<int>(sql, new
        {
            name = model.Name,
            description = model.Description,
            phaseId = model.StrokePhaseId,
            cause = model.Cause,
            correctionStrategy = model.CorrectionStrategy,
            relatedInjuryId = model.RelatedInjuryId,
            isVerified = model.IsVerified,
            createdAt = model.CreatedAt,
            createdBy = model.CreatedBy
        });
        return newId;
    }

    public async Task<int> DeleteCommonErrorsAsync(int id)
    {
        using var conn = _connectionFactory.CreateConnection();
        var rowsAffected = await conn.ExecuteAsync("DELETE FROM common_errors WHERE error_id = @id",
            new { id });
        return rowsAffected;
    }


    public CommonError MapToDomain(CommonErrorDbDto model)
    {
        return new CommonError(model.name, model.description, model.phase_id, model.phase_name, model.cause,
            model.correction_strategy, model.related_injury_id, model.related_injury_body_area)
        {
            ErrorId = model.error_id,
            IsVerified = model.is_verified,
            CreatedAt = model.created_at,
            CreatedBy = model.created_by
        };
    }
}