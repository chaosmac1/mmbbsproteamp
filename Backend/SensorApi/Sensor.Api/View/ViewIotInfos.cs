using Sensor.Api.Interface;

namespace Sensor.Api.View; 

public class ViewIotInfos: IView {
    public IReadOnlyList<ViewIotInfo> List { get; set; }
}