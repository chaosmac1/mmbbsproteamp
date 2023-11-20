using Sensor.Service.AttachmentService.Interface;
using Sensor.Service.Interface;
using Sensor.Service.Port.Interface;

namespace Sensor.Service.Dto; 

public class DtoInputAdminSetUserPassword : IDto, IDtoFrom<DtoInputAdminSetUserPassword, IInputAdminSetUserPassword> {
    public required Guid UserId { get; init; }
    public required string Password { get; init; }
    public static DtoInputAdminSetUserPassword From(IInputAdminSetUserPassword from) {
        return new DtoInputAdminSetUserPassword {
            UserId = from.UserId,
            Password = from.Password
        };
    }
}