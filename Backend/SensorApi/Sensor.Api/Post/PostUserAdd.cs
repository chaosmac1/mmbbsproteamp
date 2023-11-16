using Sensor.Service.Port.Interface;

namespace Sensor.Api.Post; 

public class PostUserAdd: IInputUserAdd {
    public required string Username { get; set; }
    public required string Password { get; set; }
}