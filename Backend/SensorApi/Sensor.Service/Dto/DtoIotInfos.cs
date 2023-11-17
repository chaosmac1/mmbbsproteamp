using Sensor.Service.AttachmentService.Interface;
using Sensor.Service.Port.Interface;

namespace Sensor.Service.Dto; 

public class DtoIotInfos: IHandlerOutput, IDto, IDtoFrom<DtoIotInfos, IIotInfos>, IIotInfos {
    public required IReadOnlyList<IIotInfo> List { get; init; }
    
    public static DtoIotInfos From(IIotInfos from) {
        return new DtoIotInfos() {
            List = from.List.Select(DtoIotInfo.From).ToList()
        };
    }
}