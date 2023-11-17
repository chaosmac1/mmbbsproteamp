using Sensor.Service.AttachmentService.Interface;
using Sensor.Service.Port.Interface;

namespace Sensor.Api.Post; 

public class PostUpdatePassword: IInputUpdatePassword, IInput {
    public required string Password { get; set; }
}