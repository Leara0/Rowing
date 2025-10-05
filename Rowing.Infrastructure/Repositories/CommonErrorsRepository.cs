using Rowing.Application.Interfaces;
using Rowing.Infrastructure.Connection;

namespace Rowing.Infrastructure.Repositories;

public class CommonErrorsRepository : ICommonErrorsRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public CommonErrorsRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory; 
    }
}