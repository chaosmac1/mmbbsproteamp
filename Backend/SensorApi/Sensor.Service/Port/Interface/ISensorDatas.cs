namespace Sensor.Service.Port.Interface; 

public interface ISensorDatas {
    public IReadOnlyList<ISensorData> SensorDatas { get; }
}