using Microsoft.AspNetCore.Mvc;
using Sensor.Api.Post;
using Sensor.Api.View;

namespace Sensor.Api.Controllers.V1.User; 

public class Setting: ControllerBase {
    [HttpGet("/V1/User/Setting/Info")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewBody<ViewUserInfo>))]
    public IResult Info() {
        throw new NotImplementedException(nameof(Info));
    }    
    
    
    [HttpPost("/V1/User/Setting/Update/Password")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewBody<ViewWork>))]
    public IResult UpdatePassword([FromBody] PostUpdatePassword post) {
        throw new NotImplementedException(nameof(UpdatePassword));
    }
}