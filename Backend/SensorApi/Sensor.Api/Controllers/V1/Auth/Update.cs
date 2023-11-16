using Microsoft.AspNetCore.Mvc;
using Sensor.Api.Post;
using Sensor.Api.View;

namespace Sensor.Api.Controllers.V1.Auth; 

public class Update: ControllerBase {
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
}