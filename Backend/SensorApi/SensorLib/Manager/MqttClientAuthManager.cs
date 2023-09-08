using Dapper;
using Npgsql;
using SensorLib.Dto;
using SensorLib.Entities;
using SensorLib.Query;

namespace SensorLib.Manager; 

public static class MqttClientAuthManager {
    public static async ValueTask<MqttClientAuthDto?> GetByNameAsync(NpgsqlConnection db, string name) {
        var result = await QueryMqttClientAuth.GetByNameAsync(db, name);
        if (result is null) return null;
        return Mapper.ToMqttClientAuthDto(result);
    }

    public static async ValueTask InsertAsync(NpgsqlConnection db, MqttClientAuth value)
        => await QueryMqttClientAuth.InsertAsync(db, value);
}