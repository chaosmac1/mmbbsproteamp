using Sensor.Service.Interface;

namespace Sensor.Service.Dto; 

public class DtoInputAdminSetUserPassword {
    public required Guid UserId { get; init; }
    public required string Password { get; init; }
}