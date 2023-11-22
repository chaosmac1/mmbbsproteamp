using Sensor.Domain.ValueObject;

namespace Sensor.Domain.Entity;

public class Graph: Sensor.Domain.Model.Entity<GraphId> {
    public required Kelvin ValueKelvin { get; set; }
    
    public Graph(GraphId id) : base(id) {
    }
}