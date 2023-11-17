namespace Sensor.Domain.ValueObject;

public class UserIdAndToken: Model.ValueObject {
    public required UserId UserId { get; set; }
    public required UserToken UserToken { get; set; }
    
    internal override IEnumerable<object> GetEquality() {
        yield return UserId;
        yield return UserToken;
    }
}