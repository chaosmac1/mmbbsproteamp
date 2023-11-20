using Microsoft.AspNetCore.Mvc;
using Sensor.Api.Extension;
using Sensor.Api.Post;
using Sensor.Api.View;
using Sensor.Service.AttachmentService;
using Sensor.Service.Dto;
using Sensor.Service.Handler;
using Sensor.Service.Port;
using Sensor.Service.Port.Interface;

namespace Sensor.Api.Controllers.V1; 

public class Auth : ControllerExtensions {
    [HttpPost("/V1/Auth/Login/User")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewBody<ViewUserLogin>))]
    public async Task<IActionResult> LoginUser([FromBody] PostUserLogin post) {
        var service = new AttachmentService<
            IInputUserLogin,        // Input
            DtoInputUserLogin,      // Dto
            HandlerLoginUser,       // Handler
            IBody<IUserLoginStatus> // HandlerOutput            
        >();
        StatusOutput<IBody<IUserLoginStatus>> value = await service.RunAsync(post, this.ApiProxyFactory(), true);
        var result = this.ToIActionResult<ViewUserLogin, IUserLoginStatus>(value);
        return result;
    }

    [HttpPost("/V1/Auth/Login/Iot")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewBody<ViewIotLoginJwtAndStatus>))]
    public async Task<IActionResult> LoginIot([FromBody] PostIotLogin post) {
        throw new NotImplementedException(nameof(LoginIot));
    }
    
    [HttpPost("/V1/Auth/Logout/User")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewBody<ViewWork>))]
    public async Task<IActionResult> UserLogout() {
        var service = new AttachmentService<
            IInputNone,        // Input
            DtoInputNone,      // Dto
            HandlerUserLogout, // Handler
            IBody<IWork>       // HandlerOutput            
        >();
        StatusOutput<IBody<IWork>> value = await service.RunAsync(new PostInputNone(), this.ApiProxyFactory(), true);
        var result = this.ToIActionResult<ViewWork, IWork>(value);
        return result;
    }
    
    [HttpPost("/V1/Auth/Update/User")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewBody<ViewWork>))]
    public async Task<IActionResult> UpdateUser() {
        throw new NotImplementedException(nameof(UpdateUser));
    }
    
    [HttpPost("/V1/Auth/Update/Iot")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewBody<ViewIotUpdate>))]
    public async Task<IActionResult> UpdateIot([FromBody] PostIotToken token) {
        throw new NotImplementedException(nameof(UpdateIot));
    }
    
    [HttpPost("/V1/Auth/Valid/User")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewBody<ViewValid>))]
    public async Task<IActionResult> ValidUserCookie() {
        throw new NotImplementedException(nameof(ValidUserCookie));
    }
    
    [HttpPost("/V1/Auth/Valid/Iot")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewBody<ViewValid>))]
    public async Task<IActionResult> ValidIotToken([FromBody] PostIotToken token) {
        throw new NotImplementedException(nameof(ValidIotToken));
    }
}