using Sensor.Api.Interface;

namespace Sensor.Api.View; 

public class ViewUserInfo: IView {
    public required string UserId { get; set; }
    public required string Username { get; set; }
}