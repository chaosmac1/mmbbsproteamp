using Sensor.Api.Interface;

namespace Sensor.Api.View; 

public class ViewSensorData: IView {
    public DateTime CreateDate { get; set; }
    public DateTime UseDate { get; set; }
    public float Kelvin { get; set; }
}