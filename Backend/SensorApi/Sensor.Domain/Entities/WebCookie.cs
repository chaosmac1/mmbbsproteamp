using Sensor.Domain.ValueObject;

namespace Sensor.Domain.Entities; 

public class WebCookie {
    public required UserToken UserToken { get; init; }
    public required UserId UserId { get; init; }
    public required DateTime CreateDate { get; init; }
}