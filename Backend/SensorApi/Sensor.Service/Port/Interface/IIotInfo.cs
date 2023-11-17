namespace Sensor.Service.Port.Interface; 

public interface IIotInfo {
    public string Name { get; }
    public DateTime LastRequest { get; }
    public bool AllowedRequest { get; }
}