using LamLibAllOver;
using Microsoft.AspNetCore.Mvc;
using NetEscapades.EnumGenerators;
using Sensor.Api.Interface;
using Sensor.Service.AttachmentService;
using Sensor.Service.AttachmentService.Interface;
using Sensor.Service.Port;
using Sensor.Service.Port.Interface;

namespace Sensor.Api.Extension;

public class ControllerExtensions : ControllerBase {
    record UserToken(string Value) : IUserToken;

    private class ApiProxy: IApiProxy {
        private readonly ControllerExtensions _controller;

        internal ApiProxy(ControllerExtensions controller) => _controller = controller;

        public Option<IUserToken> GetCookie() => _controller.GetCookieToken();

        public void SetCookie(IUserToken token) => _controller.AppendCookie(ECookie.LoginCookie, token.Value);

        public void RemoveCookie() => _controller.RemoveCookieByEName(ECookie.LoginCookie);
    }
    
    public IApiProxy ApiProxyFactory() => new ApiProxy(this);

    [EnumExtensions]
    public enum ECookie {
        LoginCookie
    }

    public Option<IUserToken> GetCookieToken() {
        HttpContext.Items.TryGetValue(ECookie.LoginCookie.ToStringFast(), out var data);

        if (data is null || data is not string)
            return default;

        var str = data as string;

        return Option<IUserToken>.With(new UserToken(str??""));
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

    public IActionResult ToIActionResult<TOut, TInput>(StatusOutput<IBody<TInput>> statusOutput) 
        where TOut : class, IView 
        where TInput : class {

        return ToIActionResult<TOut>((StatusOutput<IBody>)(object)statusOutput);
    }
    
    public IActionResult ToIActionResult<TOut>(StatusOutput<IBody> statusOutput) where TOut: class, IView {
        return statusOutput.Status switch {
            EStatus.Ok => Ok(Mapper.ToView<TOut>(statusOutput.Value.Unwrap())),
            EStatus.BadRequest => BadRequest(),
            EStatus.BadRequestMessage => BadRequest(Mapper.ToView<TOut>(statusOutput.Value.Unwrap())),
            EStatus.Forbidden => Forbid(),
            EStatus.InternelServerError => InternalServerError(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}