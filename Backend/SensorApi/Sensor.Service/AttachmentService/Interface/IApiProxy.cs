using LamLibAllOver;
using Sensor.Service.Port.Interface;

namespace Sensor.Service.AttachmentService.Interface; 

public interface IApiProxy {
    public Option<IUserToken> GetCookie();

    public void SetCookie(IUserToken token);

    public void RemoveCookie();
}