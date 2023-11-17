namespace Sensor.Domain.Model;

public abstract class ValueObject {
    internal abstract IEnumerable<object> GetEquality();
}