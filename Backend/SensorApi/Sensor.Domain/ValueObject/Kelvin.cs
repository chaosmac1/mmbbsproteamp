namespace Sensor.Domain.ValueObject;

public class Kelvin: Model.ValueObject {
    public required float Value { get; set; }
    internal override IEnumerable<object> GetEquality() {
        yield return Value;
    }
}