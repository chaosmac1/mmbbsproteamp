using LamLibAllOver;
using Org.BouncyCastle.Utilities.Net;
using SensorLib.Database;
using SensorLib.Record;

namespace SensorLib.AttachmentService.Interface; 

public interface IController {
    public Option<Token> GetCookie();

    public void SetCookie(Token token);

    public ValueTask<Option<UserIdAndToken>> GetCookieAndUserId(DbWrapper db);

    public void RemoveCookie();
}