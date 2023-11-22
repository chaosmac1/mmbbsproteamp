namespace Sensor.Domain.ValueObject;

public class GraphId: Model.ValueObject {
    public required IotId DeviceId { get; set; }
    public required DateTime Time { get; set; }
    
    internal override IEnumerable<object> GetEquality() {
        yield return DeviceId;
        yield return Time;
    }
}