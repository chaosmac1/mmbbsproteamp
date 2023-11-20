using Sensor.Domain.ValueObject;
using Sensor.Service.AttachmentService.Interface;

namespace Sensor.Service.Dto; 

public class DtoInputAdminIotUpdate: IDto {
    public required IotId Id { get; init; }
    public required string Name { get; init; }
    public required bool AllowedRequest { get; init; }
}