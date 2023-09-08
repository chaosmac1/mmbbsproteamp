using System.Net;
using LamLibAllOver;
using Microsoft.AspNetCore.Mvc;
using NetEscapades.EnumGenerators;
using Npgsql;
using SensorLib.AttachmentService;
using SensorLib.AttachmentService.Interface;
using SensorLib.Class;
using SensorLib.Database;
using SensorLib.Record;
using LamLibAllOver;
using Org.BouncyCastle.Utilities.Net;
using SensorLib.Database;
using SensorLib.Manager;
using SensorLib.Record;

namespace SensorApi.Extension;

public class ControllerExtensions : ControllerBase, IController {
    public IController AsIController() => this;

    [EnumExtensions]
    public enum ECookie {
        LoginCookie
    }

    public IActionResult ToIActionResult<T>(StatusOutput<T> v) {
        return v.Status switch {
            EStatus.Ok => Ok(v.Value.Unwrap()),
            EStatus.BadRequest => BadRequest(),
            EStatus.BadRequestMessage => BadRequest(v.Value.Unwrap()),
            EStatus.Forbidden => Forbid(),
            EStatus.InternelServerError => InternalServerError(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
    
    public Option<Token> GetCookieToken() {
        HttpContext.Items.TryGetValue(ECookie.LoginCookie.ToStringFast(), out var data);

        if (data is null || data is not string)
            return default;

        var str = data as string;

        if (!Guid.TryParse(str, out var guid)) {
            return default;
        }

        return Option<Token>.With(new Token(guid));
    }
    
    public void RemoveCookieByEName(ECookie eCookie) {
        try
        {
            Response.Cookies.Delete(eCookie.ToStringFast());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void SetLoginCookie(Token cookieToken)
        => AppendCookie(ECookie.LoginCookie, cookieToken.Value.ToString());

    private static string? ECookieToString(ECookie eCookie) {
        return eCookie switch {
            ECookie.LoginCookie => "LoginCookie",
            _ => null
        };
    }

    private void AppendCookie(ECookie eCookie, string value) {
        var eCookieToString = ECookieToString(eCookie);

        if (eCookieToString is null)
            throw new NullReferenceException(nameof(eCookieToString));
        // TODO SET SITE NAME

        Response.Cookies.Append(eCookieToString, value, new CookieOptions {
            Secure = false,
            HttpOnly = false,
            SameSite = SameSiteMode.Lax,
            MaxAge = new TimeSpan(TimeSpan.TicksPerDay * 30)
        });
    }
      
    
    public StatusCodeResult InternalServerError() => new(500);

    public Option<Token> GetCookie() => GetCookieToken();

    public void SetCookie(Token token) {
        this.AppendCookie(ECookie.LoginCookie, token.ToString() ?? string.Empty);
    }

    public async ValueTask<Option<UserIdAndToken>> GetCookieAndUserId(DbWrapper db) {
        var cookieOp = GetCookie();
        if (cookieOp.IsNotSet())
            return default;
        
        var res = await CookieTokenManager.GetCookieByTokenAsync(db.Db, cookieOp.Unwrap().Value);
        if (res.IsNotSet())
            return default;
        
        return Option<UserIdAndToken>
            .With(new UserIdAndToken(res.Unwrap().UserId, res.Unwrap().TokenId));
    }

    public void RemoveCookie() => RemoveCookieByEName(ECookie.LoginCookie);
}