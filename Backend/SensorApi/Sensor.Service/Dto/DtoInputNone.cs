using Sensor.Service.AttachmentService.Interface;
using Sensor.Service.Port.Interface;

namespace Sensor.Service.Dto; 

public class DtoInputNone: IDto, IInputNone, IDtoFrom<DtoInputNone, IInputNone> {
    public static DtoInputNone From(IInputNone from) {
        return new DtoInputNone();
    }
}