namespace Sensor.Service.Port.Interface;

public interface ISensorData {
    public float Kelvin { get; }
    public DateTime UseDate { get; }
}