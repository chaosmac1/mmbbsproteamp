using Dapper;
using Npgsql;
using Sensor.Repository.Database.Poco;

namespace Sensor.Repository.Database.Query;

public static class QueryGraph {
    public static async Task InsertAsync(NpgsqlConnection db, Graph row) {
        await db.ExecuteAsync(@"
INSERT INTO graph
    (device_id, time, value_kelvin)
VALUES 
    (@device_id, @time, @value_kelvin)
", new {
            device_id = row.device_id,
            time = row.time,
            value_kelvin = row.value_kelvin,
        });
    }
    
    public static async Task InsertOrUpdateAsync(NpgsqlConnection db, Graph row) {
        await db.ExecuteAsync(@"
INSERT INTO graph
    (device_id, time, value_kelvin)
VALUES 
    (@device_id, @time, @value_kelvin)
ON CONFLICT DO UPDATE SET value_kelvin = @value_kelvin 
", new {
            device_id = row.device_id,
            time = row.time,
            value_kelvin = row.value_kelvin,
        });
    }
    
    public static async Task<IEnumerable<Graph>> GetGraphRowByTimeRangeAsync(NpgsqlConnection db, DateTime start, DateTime end) {
        IEnumerable<Graph> result = await db.QueryAsync<Graph>(@"
SELECT * 
FROM graph 
WHERE time >= @start
  AND time <= @end
ORDER BY time
", new { start = start, end = end });

        return result.AsList();
    }
}