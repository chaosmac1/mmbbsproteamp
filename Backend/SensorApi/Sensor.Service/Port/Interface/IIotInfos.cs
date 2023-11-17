using Sensor.Service.AttachmentService.Interface;

namespace Sensor.Service.Port.Interface; 

public interface IIotInfos: IHandlerOutput {
    public IReadOnlyList<IIotInfo> List { get; }
}