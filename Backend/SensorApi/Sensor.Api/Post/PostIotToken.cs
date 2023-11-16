using Sensor.Service.Port.Interface;

namespace Sensor.Api.Post; 

public class PostIotToken: IInputToken {
    public required IIotToken Token { get; set; }
}