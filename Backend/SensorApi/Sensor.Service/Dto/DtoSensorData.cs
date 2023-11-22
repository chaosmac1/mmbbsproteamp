using Sensor.Domain.ValueObject;
using Sensor.Service.AttachmentService.Interface;
using Sensor.Service.Port.Interface;

namespace Sensor.Service.Dto; 

public class DtoSensorData: ISensorData {
    public required float Kelvin { get; init; }
    public required DateTime UseDate { get; init; }

    public ISensorData AsISensorData => this;
}