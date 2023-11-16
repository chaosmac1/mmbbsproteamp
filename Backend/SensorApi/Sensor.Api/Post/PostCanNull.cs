using Sensor.Service.Port.Interface;

namespace Sensor.Api.Post; 

public class PostCanNull<T>: ICanNull<T> {
    public required T Value { get; set; }
}