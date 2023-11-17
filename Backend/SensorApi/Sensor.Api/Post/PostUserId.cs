using Sensor.Service.AttachmentService.Interface;
using Sensor.Service.Port.Interface;

namespace Sensor.Api.Post; 

public class PostUserId: IInputUserId, IInput {
    public required Guid UserId { get; set; }
}