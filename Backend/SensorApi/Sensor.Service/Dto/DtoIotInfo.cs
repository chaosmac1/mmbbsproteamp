using Org.BouncyCastle.Asn1.Cmp;
using Sensor.Service.AttachmentService.Interface;
using Sensor.Service.Port.Interface;

namespace Sensor.Service.Dto; 

public class DtoIotInfo: IDto, IIotInfo, IDtoFrom<DtoIotInfo, IIotInfo> {
    public required string Name { get; init; }
    public required DateTime LastRequest { get; init; }
    public required bool AllowedRequest { get; init; }
    public static DtoIotInfo From(IIotInfo from) {
        return new DtoIotInfo {
            Name = from.Name,
            LastRequest = from.LastRequest,
            AllowedRequest = from.AllowedRequest,
        };
    }
}