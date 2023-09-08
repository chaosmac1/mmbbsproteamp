using Dapper;
using Npgsql;
using SensorLib.Dto;
using SensorLib.Entities;

namespace SensorLib.Query; 

public static class QueryMqttClientAuth {
    public static async ValueTask<MqttClientAuth?> GetByNameAsync(NpgsqlConnection db, string name) {
        return await db.QueryFirstOrDefaultAsync<MqttClientAuth>(@$"
SELECT * 
FROM MqttClientAuth
WHERE Name = @Name
LIMIT 1
", new { Name = name });
    }

    public static async Task InsertAsync(NpgsqlConnection db, MqttClientAuth value) {
        await db.ExecuteAsync(@$"
INSERT INTO MqttClientAuth 
    (MqttClientId, Name, Password)
VALUES 
    (@MqttClientId, @Name, @Password)
", value);
    }
}