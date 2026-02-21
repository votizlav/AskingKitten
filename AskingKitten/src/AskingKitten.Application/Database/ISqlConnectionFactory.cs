using System.Data;

namespace AskingKitten.Application.Database;

public interface ISqlConnectionFactory
{
    IDbConnection Create();
}