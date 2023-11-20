using Sensor.Service.AttachmentService.Interface;
using Sensor.Service.Port.Interface;

namespace Sensor.Service.Dto; 

public class DtoInputUserLogin: IDto, IDtoFrom<DtoInputUserLogin, IInputUserLogin> {
    public required string Username { get; init; }
    public required string Password { get; init; }
    public static DtoInputUserLogin From(IInputUserLogin from) {
        return new DtoInputUserLogin() {
            Password = from.Password,
            Username = from.Username
        };
    }
}