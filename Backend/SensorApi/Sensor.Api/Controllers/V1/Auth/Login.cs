using Microsoft.AspNetCore.Mvc;
using Sensor.Api.Post;
using Sensor.Api.View;

namespace Sensor.Api.Controllers.V1.Auth; 

public class Login: ControllerBase {
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
}