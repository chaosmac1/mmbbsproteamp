using Sensor.Api.Interface;
using Sensor.Service.Port.Interface;

namespace Sensor.Api.View; 

public class ViewIotInfos: IView {
    public required IReadOnlyList<ViewIotInfo> List { get; set; }
}