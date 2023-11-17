using Sensor.Domain.ValueObject;

namespace Sensor.Service.Dto; 

public class DtoInputIotLogin {
    public required IotId IotName { get; init; }
    public required string Password { get; init; }
}