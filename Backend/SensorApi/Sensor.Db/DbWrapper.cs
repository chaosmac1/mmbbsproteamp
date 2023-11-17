using Npgsql;
using Sensor.Domain.Interface;

namespace Sensor.Db; 

public class DbWrapper: IDbWrapper {
    private bool _rollback;
    private readonly NpgsqlTransaction _transaction;
    private readonly NpgsqlConnection _db;

    public Npgsql.NpgsqlConnection Db {
        get {
            if (_rollback) {
                throw new Exception("Status Rollback");
            }
            return _db;
        }
        private init => _db = value;
    }
    
    public DbWrapper(NpgsqlTransaction transaction, NpgsqlConnection db) {
        _transaction = transaction;
        Db = db;
    }

    public static async Task<IDbWrapper> FactoryAsync() {
        var db = await BuildDb.BuildNpgsqlAsync();
        var transaction = await db.BeginTransactionAsync();
        return new DbWrapper(transaction, db);
    }
    
    public async Task RollbackAsync() {
        if (_rollback) return;
        _rollback = true;
        try {
            await _transaction.RollbackAsync();
            await _db.CloseAsync();
        }
        catch (Exception) {
            // ignored
        }
    }

    public Task CommitAsync() {
        if (_rollback) return Task.CompletedTask;
        
        return _transaction.CommitAsync();
    }
    
    public async ValueTask DisposeAsync() {
        try {
            await _transaction.DisposeAsync();
            await _db.DisposeAsync();
        }
        catch (Exception) {
            // ignored
        }
    }
}