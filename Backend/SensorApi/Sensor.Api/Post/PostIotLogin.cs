using Sensor.Service.Port.Interface;

namespace Sensor.Api.Post; 

public class PostIotLogin: IInputIotLogin {
    public required string IotName { get; set; }
    public required string Password { get; set; }
}