using Sensor.Domain.ValueObject;
using Sensor.Service.AttachmentService.Interface;
using Sensor.Service.Port.Interface;

namespace Sensor.Service.Dto;

public record DtoInputAdminIotDelete(Guid IotId) : IDto, IInputAdminIotDelete, IDtoFrom<DtoInputAdminIotDelete, IInputAdminIotDelete> {
    public static DtoInputAdminIotDelete From(IInputAdminIotDelete from) {
        return new DtoInputAdminIotDelete(from.IotId);
    }
}