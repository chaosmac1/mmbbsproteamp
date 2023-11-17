using Sensor.Domain.ValueObject;

namespace Sensor.Service.Dto; 

public record DtoSensorData(
    IotId Id,
    Kelvin Temp
);