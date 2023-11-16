using Dapper;
using Npgsql;
using SensorLib.Entities;

namespace SensorLib.Query; 

public static class QuerySensorTemp {
    public static async ValueTask InsertAsync(NpgsqlConnection db, SensorTemp value) {
        await db.ExecuteAsync(@$"
INSERT INTO SensorTemp 
    (MqttClientId, CreateDate, UseDate, Value)   
VALUES
    (@MqttClientId, @CreateDate, @UseDate, @Value)
", value);
    }

    public static async ValueTask<IEnumerable<SensorTemp>> GetByRangeDateAndGroupByUseDateAsync(NpgsqlConnection db, DateTime start, DateTime end) {
        return await db.QueryAsync<SensorTemp>(@$"
SELECT UseDate, MAX(Value)
FROM SensorTemp
WHERE UseDate >= @Start AND UseDate <= @End
GROUP BY UseDate
", new {Start = start, End = end});
    }
}