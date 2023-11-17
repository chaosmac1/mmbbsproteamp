using Sensor.Service.AttachmentService.Interface;
using Sensor.Service.Port.Interface;

namespace Sensor.Api.Post; 

public class PostIotToken: IInputToken, IInput {
    public required string Token { get; set; }
}