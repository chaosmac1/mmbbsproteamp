namespace Sensor.Service.Port.Interface; 

public interface IValid {
    public bool IsValid { get; }
    public DateTime ValidEndDate { get; }
}