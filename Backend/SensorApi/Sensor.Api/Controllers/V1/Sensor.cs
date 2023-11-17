using Microsoft.AspNetCore.Mvc;
using Sensor.Api.Extension;
using Sensor.Api.View;

namespace Sensor.Api.Controllers.V1; 

public class Sensor : ControllerExtensions {
    [HttpGet("/V1/Sensor")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewBody<ViewSensorData>))]
    public IResult GetSensorData([FromQuery()] string amount) {
        throw new NotImplementedException(nameof(GetSensorData));
    }

    [HttpPost("/V1/Sensor")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewBody<ViewSensorData>))]
    public IResult PostSensorData() {
        throw new NotImplementedException(nameof(GetSensorData));
    }
}