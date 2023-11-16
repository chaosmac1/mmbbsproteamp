using System.Data;
using Npgsql;

namespace Sensor.Core.Database; 

public class DbWrapper: IAsyncDisposable {
    private bool _rollback;
    private readonly NpgsqlTransaction _transaction;
    
    public NpgsqlConnection Db { get; }
    
    private DbWrapper(NpgsqlTransaction transaction, NpgsqlConnection db) {
        _transaction = transaction;
        Db = db;
    }

    public static async Task<DbWrapper> BuildAsync() {
        var conn = await DbBuilder.BuildNpgsqlAsync();
            
        var transaction = await conn.BeginTransactionAsync(IsolationLevel.Serializable);

        return new DbWrapper(transaction, transaction.Connection!);
    }
    
    public async ValueTask RollbackAsync() {
        if (_rollback) return;
        await _transaction.RollbackAsync();
        _rollback = true;
    }

    public async ValueTask CommitAsync() {
        if (_rollback) return;
        
        await _transaction.CommitAsync();
    }

    public async ValueTask DisposeAsync() {
        var task = _transaction.DisposeAsync();
        await task;
        await Db.DisposeAsync();
    }
}