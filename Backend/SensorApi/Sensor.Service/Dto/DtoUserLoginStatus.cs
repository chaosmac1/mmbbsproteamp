using System.Runtime.CompilerServices;
using Sensor.Service.AttachmentService.Interface;
using Sensor.Service.Port.Interface;

namespace Sensor.Service.Dto; 

public class DtoUserLoginStatus: IDto, IHandlerOutput, IUserLoginStatus, IDtoFrom<DtoUserLoginStatus, IUserLoginStatus> {
    public required string Status { get; init; }
    public static DtoUserLoginStatus From(IUserLoginStatus from) {
        return new DtoUserLoginStatus() { Status = from.Status };
    }

    public IUserLoginStatus AsUserLoginStatus() => this;
}