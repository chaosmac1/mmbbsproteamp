using Microsoft.AspNetCore.Mvc;
using Sensor.Api.Post;
using Sensor.Api.Post;
using Sensor.Api.View;

namespace Sensor.Api.Controllers.V1.Admin;

public class Iot : ControllerBase {
    [HttpGet("/V1/Admin/Iot/Infos")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewBody<ViewIotInfos>))]
    public IResult IotInfos() {
        throw new NotImplementedException(nameof(IotInfos));
    }

    [HttpPost("/V1/Admin/Iot/Update")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewBody<ViewIotInfo>))]
    public IResult IotInfos([FromBody] PostAdminIotUpdate post) {
        throw new NotImplementedException(nameof(IotInfos));
    }

    [HttpPost("/V1/Admin/Iot/Delete")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewBody<ViewIotInfos>))]
    public IResult IotDelete([FromBody] PostAdminIotDelete post) {
        throw new NotImplementedException(nameof(IotDelete));
    }
    
    [HttpPost("/V1/Admin/Iot/Insert")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewBody<ViewIotInfos>))]
    public IResult IotInsert([FromBody] PostAdminIotInsert post) {
        throw new NotImplementedException(nameof(IotInsert));
    }
}
