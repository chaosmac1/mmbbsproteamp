using Sensor.Domain.ValueObject;

namespace Sensor.Domain.Entity; 

public class GraphRow: Sensor.Domain.Model.Entity<GraphRowId> {
    public required IotId DeviceId { get; set; }
    public required DateTime Time { get; set; }

    public DateTime UseDate {
        get {
            var sec = UseDate.Second;    //  53
            var useSec = sec / 10 * 10;  //  50
            var diff = useSec - sec;     // -03 
            var useDate = UseDate.AddSeconds(diff);
            
            return useDate;
        }
    }

    public required Kelvin ValueKelvin { get; set; }

    public GraphRow(GraphRowId id) : base(id) {
        Id = id;
    }
}