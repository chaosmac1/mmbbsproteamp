using Sensor.Service.AttachmentService.Interface;
using Sensor.Service.Port.Interface;

namespace Sensor.Api.Post; 

public class PostCanNull<T>: ICanNull<T>, IInput where T: class {
    public required T Value { get; set; }
}