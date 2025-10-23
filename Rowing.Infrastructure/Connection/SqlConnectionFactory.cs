using System.Data;
using Microsoft.Data.SqlClient;


namespace Rowing.Infrastructure.Connection;

public class SqlConnectionFactory :IDbConnectionFactory
{
    private readonly string _connectionString;

    public SqlConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    public IDbConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }
}