namespace Sensor.Service.Port.Interface;

public interface ISensorData {
    public string IotId { get; }
    public float Kelvin { get; }
    public DateTime CreateDate { get; }
    public DateTime UseDate { get; }
}