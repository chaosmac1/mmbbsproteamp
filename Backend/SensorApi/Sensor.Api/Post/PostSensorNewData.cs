using Sensor.Service.AttachmentService.Interface;
using Sensor.Service.Port.Interface;

namespace Sensor.Api.Post;

public class PostSensorNewData: IInput, IInputSensorNewData {
    public required string Token { get; set; }
    public required float Kelvin { get; set; }
}