namespace Sensor.Domain.ValueObject;

public class IotId : Model.ValueObject {
    public required Guid Value { get; set; }
    internal override IEnumerable<object> GetEquality() {
        yield return Value;
    }
}