using Sensor.Service.Port.Interface;

namespace Sensor.Service.Dto; 

public class DtoUserInfos: IUserInfos {
    public required IList<IUserInfo> List { get; init; }
}