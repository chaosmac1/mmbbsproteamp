using Sensor.Service.AttachmentService.Interface;

namespace Sensor.Service.Port.Interface;

public interface IInputAdminIotUpdate: IInput {
    public Guid IotId { get; }
    public string Name { get; }
    public bool AllowedRequest { get; }
}