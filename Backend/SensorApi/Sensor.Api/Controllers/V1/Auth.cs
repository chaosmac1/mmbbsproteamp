using Microsoft.AspNetCore.Mvc;
using Sensor.Api.Extension;
using Sensor.Api.Post;
using Sensor.Api.View;

namespace Sensor.Api.Controllers.V1; 

public class Auth : ControllerExtensions {
    [HttpPost("/V1/Auth/Login/User")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewBody<ViewUserLogin>))]
    public IResult LoginUser([FromBody] PostUserLogin post) {
        throw new NotImplementedException(nameof(LoginUser));
    }

    [HttpPost("/V1/Auth/Login/Iot")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewBody<ViewIotLogin>))]
    public IResult LoginIot([FromBody] PostIotLogin post) {
        throw new NotImplementedException(nameof(LoginIot));
    }
    
    [HttpPost("/V1/Auth/Logout/User")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewBody<ViewWork>))]
    public IResult UserLogout() {
        throw new NotImplementedException(nameof(UserLogout));
    }
    
    [HttpPost("/V1/Auth/Update/User")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewBody<ViewWork>))]
    public IResult UpdateUser() {
        throw new NotImplementedException(nameof(UpdateUser));
    }
    
    [HttpPost("/V1/Auth/Update/Iot")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewBody<ViewIotUpdate>))]
    public IResult UpdateIot([FromBody] PostIotToken token) {
        throw new NotImplementedException(nameof(UpdateIot));
    }
    
    [HttpPost("/V1/Auth/Valid/User")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewBody<ViewValid>))]
    public IResult ValidUserCookie() {
        throw new NotImplementedException(nameof(ValidUserCookie));
    }
    
    [HttpPost("/V1/Auth/Valid/Iot")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewBody<ViewValid>))]
    public IResult ValidIotToken([FromBody] PostIotToken token) {
        throw new NotImplementedException(nameof(ValidIotToken));
    }
}