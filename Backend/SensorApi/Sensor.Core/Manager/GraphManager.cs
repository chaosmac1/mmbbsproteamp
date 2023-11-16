using Npgsql;
using Sensor.Domain.Entities;

namespace Sensor.Core.Manager; 

public static class GraphManager {
    public static GraphRows BuildGraph(NpgsqlConnection db, DateTime start, DateTime end, TimeSpan stamp) {
        throw new NotImplementedException(nameof(BuildGraph));
    }
}