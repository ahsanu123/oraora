using LearnRazor.Builder.Services;
using Microsoft.Data.Sqlite;

namespace LearnRazor.Repository;

public abstract class BaseRepository
{
    private readonly ISqliteConnectionProvider _conn;

    public BaseRepository(ISqliteConnectionProvider connectionProvider)
    {
        _conn = connectionProvider;
    }

    public async Task CreateConnection(Func<SqliteConnection, Task> connection)
    {
        using var conn = _conn.CreateConnection();
        await connection(conn);
    }
}
