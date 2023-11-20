using Sensor.Domain.ValueObject;
using Sensor.Service.AttachmentService.Interface;
using Sensor.Service.Port.Interface;

namespace Sensor.Api.Post; 

public class PostAdminIotUpdate: IInputAdminIotUpdate, IInput {
    public required Guid IotId { get; set; }
    public required string Name { get; set; }
    public required bool AllowedRequest { get; set; }
}