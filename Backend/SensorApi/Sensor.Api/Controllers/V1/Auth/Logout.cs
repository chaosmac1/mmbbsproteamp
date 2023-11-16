using Microsoft.AspNetCore.Mvc;
using Sensor.Api.Post;
using Sensor.Api.View;

namespace Sensor.Api.Controllers.V1.Auth; 

public class Logout: ControllerBase {
    [HttpPost("/V1/Auth/Logout/User")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewBody<ViewWork>))]
    public IResult UserLogout() {
        throw new NotImplementedException(nameof(UserLogout));
    }
}