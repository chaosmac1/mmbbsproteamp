using Sensor.Service.AttachmentService.Interface;
using Sensor.Service.Port.Interface;

namespace Sensor.Service.Dto; 

public class DtoUserId: IDto, IDtoFrom<DtoUserId, IInputUserId> {
    public Guid Value { get; set; }
    public static DtoUserId From(IInputUserId from) {
        return new DtoUserId() {Value = from.UserId };
    }
}