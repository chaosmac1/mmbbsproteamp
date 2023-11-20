using Sensor.Service.AttachmentService.Interface;

namespace Sensor.Service.Port.Interface;

public interface IInputAdminIotDelete: IInput {
    public Guid IotId { get; }
}