using Sensor.Service.AttachmentService.Interface;
using Sensor.Service.Port.Interface;

namespace Sensor.Service.Dto;

public class DtoSensorDatas: IDto, ISensorDatas {
    public required IReadOnlyList<ISensorData> SensorDatas  { get; init; }
}