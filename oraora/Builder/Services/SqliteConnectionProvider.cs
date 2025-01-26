using LearnRazor.Models.Binding;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Options;

namespace LearnRazor.Builder.Services;

public interface ISqliteConnectionProvider
{
    public SqliteConnection CreateConnection();
}

public class SqliteConnectionProvider : ISqliteConnectionProvider
{
    private readonly ConnectionStrings _connString;

    public SqliteConnectionProvider(IOptions<ConnectionStrings> connString)
    {
        _connString = connString.Value;
    }

    public SqliteConnection CreateConnection()
    {
        return new SqliteConnection(_connString.Sqlite);
    }
}
