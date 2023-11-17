using Npgsql;

namespace Sensor.Domain.Interface; 

public interface IDbWrapper: IAsyncDisposable {
    public Npgsql.NpgsqlConnection Db { get; }

    public Task RollbackAsync();

    public Task CommitAsync();
}