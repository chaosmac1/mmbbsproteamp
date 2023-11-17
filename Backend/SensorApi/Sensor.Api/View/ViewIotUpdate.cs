using Sensor.Api.Interface;

namespace Sensor.Api.View; 

public class ViewIotUpdate: IView {
    public required string Token { get; set; }
}