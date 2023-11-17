using Sensor.Service.AttachmentService.Interface;
using Sensor.Service.Port.Interface;

namespace Sensor.Api.Post; 

public class PostUserAdd: IInputUserAdd, IInput {
    public required string Username { get; set; }
    public required string Password { get; set; }
}