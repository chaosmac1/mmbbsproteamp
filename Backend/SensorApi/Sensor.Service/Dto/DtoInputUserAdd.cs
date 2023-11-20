using Sensor.Service.AttachmentService.Interface;
using Sensor.Service.Port.Interface;

namespace Sensor.Service.Dto; 

public class DtoInputUserAdd : IDto, IDtoFrom<DtoInputUserAdd, IInputUserAdd> {
    public required string Username { get; init; }
    public required string Password { get; init; }
    public static DtoInputUserAdd From(IInputUserAdd from) {
        return new DtoInputUserAdd() {
            Password = from.Password,
            Username = from.Username
        };
    }
}