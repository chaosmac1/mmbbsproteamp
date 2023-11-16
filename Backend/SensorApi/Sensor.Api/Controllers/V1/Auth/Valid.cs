using Microsoft.AspNetCore.Mvc;
using Sensor.Api.Post;
using Sensor.Api.View;

namespace Sensor.Api.Controllers.V1.Auth; 

public class Valid: ControllerBase {
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