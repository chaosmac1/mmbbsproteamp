using Sensor.Domain.ValueObject;

namespace Sensor.Service.Dto; 

public class DtoInputAdminIotUpdate {
    public required IotId Id { get; init; }
    public required DtoCanNull<IotId> UpdateId { get; init; }
    public required bool AllowedRequest { get; init; }
}