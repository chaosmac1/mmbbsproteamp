using Sensor.Service.Port.Interface;

namespace Sensor.Service.Dto; 

public class DtoUserInfo: IUserInfo {
    public required Guid UserId { get; init; }
    public required string Username { get; init; }

    public IUserInfo AsIUserInfo => this;
}