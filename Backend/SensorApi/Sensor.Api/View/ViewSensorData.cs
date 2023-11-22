using Sensor.Api.Interface;
using Sensor.Service.Port.Interface;

namespace Sensor.Api.View; 

public class ViewSensorData: IView {
    public required DateTime UseDate { get; set; }
    public required float Kelvin { get; set; }
}