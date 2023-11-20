using Sensor.Domain.ValueObject;
using Sensor.Service.AttachmentService.Interface;
using Sensor.Service.Interface;

namespace Sensor.Service.Dto; 

public record DtoInputAdminIotInsert(string Name): IDto, IInputAdminIotInsert, IDtoFrom<DtoInputAdminIotInsert, IInputAdminIotInsert> {
    public static DtoInputAdminIotInsert From(IInputAdminIotInsert from) {
        return new DtoInputAdminIotInsert(from.Name);
    }
}