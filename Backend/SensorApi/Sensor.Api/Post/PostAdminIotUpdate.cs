using Sensor.Domain.ValueObject;
using Sensor.Service.AttachmentService.Interface;
using Sensor.Service.Port.Interface;

namespace Sensor.Api.Post; 

public class PostAdminIotUpdate: IInputAdminIotUpdate<PostCanNull<string>>, IInput {
    public required Guid IotId { get; set; }
    public required PostCanNull<string> UpdateId { get; set; }
    public required bool AllowedRequest { get; set; }
}