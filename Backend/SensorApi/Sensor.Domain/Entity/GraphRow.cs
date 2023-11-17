using Sensor.Domain.ValueObject;

namespace Sensor.Domain.Entity; 

public class GraphRow: Sensor.Domain.Model.Entity<GraphRowId> {
    public required IotId DeviceId { get; set; }
    public required DateTime Time { get; set; }
    public required Kelvin ValueKelvin { get; set; }

    public GraphRow(GraphRowId id) : base(id) {
        Id = id;
    }
}