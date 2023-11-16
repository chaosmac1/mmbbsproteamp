using Sensor.Service.Port.Interface;

namespace Sensor.Api.Post; 

public class PostUserId: IInputUserId {
    public required string UserId { get; set; }
}