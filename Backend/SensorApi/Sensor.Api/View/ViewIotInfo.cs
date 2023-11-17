using Sensor.Api.Interface;
using Sensor.Service.Port.Interface;

namespace Sensor.Api.View; 

public class ViewIotInfo: IView {
    public required string Name { get; set; }
    public required DateTime LastRequest { get; set; }
    public required bool AllowedRequest { get; set; }
}