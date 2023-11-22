using Sensor.Service.AttachmentService.Interface;
using Sensor.Service.Port.Interface;

namespace Sensor.Service.Dto; 

public record DtoAmount(int Amount) : IDto, IDtoFrom<DtoAmount, IAmount> {
    public static DtoAmount From(IAmount from) {
        return new DtoAmount(from.Amount);
    }
}