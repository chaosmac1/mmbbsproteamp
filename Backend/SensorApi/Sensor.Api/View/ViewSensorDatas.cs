using Sensor.Api.Interface;

namespace Sensor.Api.View; 

public class ViewSensorDatas: IView {
    public IReadOnlyList<ViewSensorData>? SensorDatas { get; set; }
}