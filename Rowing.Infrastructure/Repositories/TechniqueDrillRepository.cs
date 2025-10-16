using Rowing.Application.Interfaces;
using Rowing.Infrastructure.Connection;

namespace Rowing.Infrastructure.Repositories;

public class TechniqueDrillRepository : ITechniqueDrillRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public TechniqueDrillRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

}