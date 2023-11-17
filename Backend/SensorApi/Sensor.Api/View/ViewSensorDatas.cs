using Sensor.Api.Interface;

namespace Sensor.Api.View; 

public class ViewSensorDatas: IView {
    public required IReadOnlyList<ViewSensorData> SensorDatas { get; set; }
}