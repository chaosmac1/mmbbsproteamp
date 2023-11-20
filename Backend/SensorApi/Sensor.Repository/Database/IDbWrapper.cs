using Npgsql;

namespace Sensor.Repository.Database; 

public interface IDbWrapper: IAsyncDisposable {
    public Npgsql.NpgsqlConnection Db { get; }

    public Task RollbackAsync();

    public Task CommitAsync();
}