using Sensor.Service.AttachmentService.Interface;
using Sensor.Service.Port.Interface;

namespace Sensor.Service.Dto; 

public class DtoUserToken: IDto, IUserToken {
    public string Value { get; set; }

    public static DtoUserToken From(Domain.ValueObject.UserToken userToken) {
        return new DtoUserToken { Value = userToken.Value };
    }
}