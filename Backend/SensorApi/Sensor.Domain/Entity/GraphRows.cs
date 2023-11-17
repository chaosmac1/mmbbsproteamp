using Sensor.Domain.ValueObject;

namespace Sensor.Domain.Entity; 

public class GraphRows: Sensor.Domain.Model.Entity<Guid> {
    public required DateTime Start { get; set; }
    public required DateTime End { get; set; }
    public required List<GraphRow> Rows { get; set; }

    public GraphRows(Guid id) : base(id) => Id = id;
}