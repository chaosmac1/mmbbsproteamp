using Sensor.Service.Port.Interface;

namespace Sensor.Service.Dto; 

public class DtoUserIdAndToken: IUserIdAndToken {
    public required Guid UserId { get; init; }
    public required string CookieToken { get; init; }
}