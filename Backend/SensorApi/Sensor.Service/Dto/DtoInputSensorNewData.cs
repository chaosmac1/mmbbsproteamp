using Sensor.Service.AttachmentService.Interface;
using Sensor.Service.Port.Interface;

namespace Sensor.Service.Dto;

public class DtoInputSensorNewData: IInputSensorNewData, IDtoFrom<DtoInputSensorNewData, IInputSensorNewData>, IDto {
    public required string Token { get; set; }
    public required float Kelvin { get; set; }
    public static DtoInputSensorNewData From(IInputSensorNewData from) {
        return new DtoInputSensorNewData {
            Kelvin = from.Kelvin,
            Token = from.Token
        };
    }
}