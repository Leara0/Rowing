using Dapper;
using Rowing.Application.Interfaces;
using Rowing.Domain.Entities;
using Rowing.Infrastructure.Connection;
using Rowing.Infrastructure.DbModels;

namespace Rowing.Infrastructure.Repositories;

public class CommonErrorsRepository : ICommonErrorsRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public CommonErrorsRepository(IDbConnectionFactory connectionFactory)
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
    
    public CommonError MapToDomain(CommonErrorDbDto dto)
    {
        var domainEntity = new CommonError
        {
            ErrorId = dto.error_id,
            IsVerified = dto.is_verified,
            CreatedAt = dto.created_at,
            CreatedBy = dto.created_by
        };
        domainEntity.SetName(dto.name);
        domainEntity.SetDescription(dto.description);
        domainEntity.SetStrokePhaseId(dto.phase_id);
        domainEntity.SetStrokePhaseName(dto.phase_name);
        domainEntity.SetCause(dto.cause);
        domainEntity.SetCorrectionStrategy(dto.correction_strategy);
        domainEntity.SetRelatedInjuryId(dto.related_injury_id);
        domainEntity.SetRelatedInjuryBodyArea(dto.related_injury_body_area);
        throw new NotImplementedException();
    }
}