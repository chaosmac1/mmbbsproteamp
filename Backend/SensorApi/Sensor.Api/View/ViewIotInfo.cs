using Sensor.Api.Interface;

namespace Sensor.Api.View; 

public class ViewIotInfo: IView {
    public ViewIotName? Name { get; set; }
    public DateTime LastRequest { get; set; }
    public bool AllowedRequest { get; set; }
}