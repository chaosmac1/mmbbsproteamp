using Org.BouncyCastle.Asn1.X509;
using Sensor.Domain.ValueObject;
using Sensor.Service.AttachmentService.Interface;
using Sensor.Service.Port.Interface;

namespace Sensor.Service.Dto; 

public class DtoInputAdminIotUpdate: IDto, IInputAdminIotUpdate, IDtoFrom<DtoInputAdminIotUpdate, IInputAdminIotUpdate> {
    public required Guid IotId { get; init; }
    public required string Name { get; init; }
    public required bool AllowedRequest { get; init; }
    public static DtoInputAdminIotUpdate From(IInputAdminIotUpdate from) {
        return new DtoInputAdminIotUpdate {
            Name = from.Name,
            AllowedRequest = from.AllowedRequest,
            IotId = from.IotId
        };
    }
}