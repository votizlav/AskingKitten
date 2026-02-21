using System.Data;
using AskingKitten.Application.Database;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace AskingKitten.Infrastructure.Postgresql;

public class SqlConnectionFactory : ISqlConnectionFactory
{
    private readonly IConfiguration _configuration;

    public SqlConnectionFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IDbConnection Create()
    {
        return new NpgsqlConnection(_configuration.GetConnectionString("Database"));
    }
}