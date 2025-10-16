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

    
    
    public TechniqueDrill MapToDomain(TechniqueDrillDbDto model)
    {
        return new TechniqueDrill(model.name, model.focus_area, model.description, model.execution_steps,
            model.coaching_points, model.progression)
        {
            CreatedAt = model.created_at,
            CreatedBy = model.created_by,
            IsVerified = model.is_verified
        };
    }
}