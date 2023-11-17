using Sensor.Service.AttachmentService.Interface;
using Sensor.Service.Port.Interface;

namespace Sensor.Api.Post; 

public class PostIotLogin: IInputIotLogin, IInput {
    public required string IotName { get; set; }
    public required string Password { get; set; }
}