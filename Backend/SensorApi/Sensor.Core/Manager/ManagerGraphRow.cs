using Npgsql;
using Sensor.Repository.Database.Query;

namespace Sensor.Core.Manager;

public static class ManagerGraphRow {
    public static async Task<GraphRows> GetGraphRowByTimeRangeAsync(NpgsqlConnection db, DateTime start, DateTime end) {
        var rows = (await QueryGraph.GetGraphRowByTimeRangeAsync(db, start, end)).Select((a, b) => {
            return new GraphRow(new () { Value = b }) {
                Time = a.time,
                DeviceId = new () { Value = a.device_id },
                ValueKelvin = new () { Value = a.value_kelvin },
            };
        }).ToList();
        
        return new GraphRows(Guid.NewGuid()) {
            Start = rows[0].UseDate,
            End = rows[^1].UseDate,
            Rows = rows
        };
    }
}