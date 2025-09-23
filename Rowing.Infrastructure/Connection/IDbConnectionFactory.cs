using System.Data;

namespace Rowing.Infrastructure.Connection;

public interface IDbConnectionFactory
{
    IDbConnection CreateConnection();
}