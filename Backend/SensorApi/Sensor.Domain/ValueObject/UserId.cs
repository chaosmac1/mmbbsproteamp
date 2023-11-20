namespace Sensor.Domain.ValueObject;

public class UserId: Model.ValueObject {
    public required Guid Value { get; set; }
    internal override IEnumerable<object> GetEquality() {
        yield return Value;
    }

    public static UserId NewUserId() => new UserId() {Value = Guid.NewGuid()};
}