using Npgsql;
using Sensor.Repository.Database.Query;

namespace Sensor.Core.Manager;

public static class ManagerGraph {
    public static async Task InsertOrUpdateAsync(NpgsqlConnection db, Entity.Graph row) {
        await QueryGraph.InsertOrUpdateAsync(db, Parse.ToPocoGraph(row));
    }
}