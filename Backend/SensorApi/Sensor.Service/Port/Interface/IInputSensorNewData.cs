using Sensor.Service.AttachmentService.Interface;

namespace Sensor.Service.Port.Interface;

public interface IInputSensorNewData: IInput {
    public string Token { get; }
    public float Kelvin { get; }
}