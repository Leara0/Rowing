using Rowing.Application.Interfaces;
using Rowing.Infrastructure.Connection;

namespace Rowing.Infrastructure.Repositories;

public class TrainingWorkoutRepository : ITrainingWorkoutRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public TrainingWorkoutRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
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