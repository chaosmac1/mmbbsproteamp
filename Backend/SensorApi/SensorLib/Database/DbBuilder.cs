using Dapper;
using Npgsql;

namespace SensorLib.Database; 

public static class DbBuilder {
    private static string? _npgsqlConnectionString;
    
    public static async ValueTask<NpgsqlConnection> BuildNpgsqlAsync() {
        CreateSettingsIfNotExist();
        
        var npgsql = new NpgsqlConnection(_npgsqlConnectionString);
        await npgsql.OpenAsync();
        return npgsql;
    }
    
    private static void CreateSettingsIfNotExist() {
        if (!string.IsNullOrEmpty(_npgsqlConnectionString)) return;
        
        var connStringBuilder = new NpgsqlConnectionStringBuilder();
        connStringBuilder.Host = Env.DbIp;
        connStringBuilder.Port = Env.DbPort;
        connStringBuilder.Password = Env.DbPassword;
        connStringBuilder.Username = Env.DbUsername;
        connStringBuilder.Database = "mqtt";
        connStringBuilder.Pooling = true;
        connStringBuilder.MaxPoolSize = 3000;
        connStringBuilder.MinPoolSize = 100;
        connStringBuilder.Timeout = 1024;
        connStringBuilder.Multiplexing = true;
        _npgsqlConnectionString = connStringBuilder.ConnectionString;
    }
}