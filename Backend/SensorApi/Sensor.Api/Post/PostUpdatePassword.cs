using Sensor.Service.Port.Interface;

namespace Sensor.Api.Post; 

public class PostUpdatePassword: IInputUpdatePassword {
    public required string Password { get; set; }
}