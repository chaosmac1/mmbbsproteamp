using Npgsql;
using Sensor.Repository.Database;

namespace Sensor.Db; 

public static class BuildDb {
    private static string? _npgsqlConnectionWithMultiplexingString;
    
    public static async Task<NpgsqlConnection> BuildNpgsqlAsync() {
        CreateSettingsIfNotExistWithMultiplexing();
        var npgsql = new NpgsqlConnection(_npgsqlConnectionWithMultiplexingString);
        await npgsql.OpenAsync();
        return npgsql;
    }
    
    public static async Task<NpgsqlConnection> BuildNpgsqlNoMultiplexingAsync() {
        var npgsql = new NpgsqlConnection(SettingsBuilder(false).ToString());
        await npgsql.OpenAsync();
        return npgsql;
    }
    
    private static void CreateSettingsIfNotExistWithMultiplexing() {
        if (!string.IsNullOrEmpty(_npgsqlConnectionWithMultiplexingString)) return;
        _npgsqlConnectionWithMultiplexingString = SettingsBuilder().ConnectionString;
    }

    public static NpgsqlConnectionStringBuilder SettingsBuilder(bool multiplexing = true) {
        var connStringBuilder = new NpgsqlConnectionStringBuilder();
        connStringBuilder.Host         = Setting.Host; 
        connStringBuilder.Port         = Setting.Port; 
        connStringBuilder.Password     = Setting.Password; 
        connStringBuilder.Username     = Setting.Username; 
        connStringBuilder.Database     = Setting.Database; 
        connStringBuilder.Pooling      = Setting.Pooling; 
        connStringBuilder.MaxPoolSize  = Setting.MaxPoolSize; 
        connStringBuilder.MinPoolSize  = Setting.MinPoolSize; 
        connStringBuilder.Timeout      = Setting.Timeout; 
        connStringBuilder.Multiplexing = multiplexing;
        return connStringBuilder;
    }
}