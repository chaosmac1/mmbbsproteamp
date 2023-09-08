using LamLibAllOver;
using Org.BouncyCastle.Utilities.Net;

namespace SensorLib.AttachmentService.Interface; 

public interface IController {
    public Option<Token> GetCookie();

    public string SetCookie(Token token);

    public ValueTask<Option<UserIdAndToken>> GetCookieAndUserId(DbWrapper db);

    public Option<IPAddress> GetIpAddress();

    public void RemoveCookie();
}