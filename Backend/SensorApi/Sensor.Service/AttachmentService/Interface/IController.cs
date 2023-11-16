using LamLibAllOver;
using Sensor.Core.Database;
using Sensor.Service.Port.Interface;

namespace Sensor.Service.AttachmentService.Interface; 

public interface IController {
    public Option<IUserToken> GetCookie();

    public void SetCookie(IUserToken token);

    public void RemoveCookie();
}