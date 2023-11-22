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

public class Sensor : ControllerExtensions {
    [HttpGet("/V1/Sensor")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewBody<ViewSensorDatas>))]
    public async Task<IActionResult> GetSensorData([FromQuery(Name = "amount")] int amount) {
        var post = new PostAmount() { Amount = amount };
        
        var service = new AttachmentService<
            IAmount,                // Input
            DtoAmount,  // Dto
            HandlerSensorAddTemp,   // Handler
            IBody<ISensorData>      // HandlerOutput            
        >();
        
        StatusOutput<IBody<ISensorData>> value = await service.RunAsync(post, this.ApiProxyFactory(), true);
        var result = this.ToIActionResult<ViewSensorData, ISensorData>(value);
        return result;
    }

    [HttpPost("/V1/Sensor")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewBody<ViewSensorData>))]
    public async Task<IActionResult> PostSensorData([FromBody] PostSensorNewData post) {
        var service = new AttachmentService<
            IInputSensorNewData,    // Input
            DtoInputSensorNewData,  // Dto
            HandlerSensorAddTemp,   // Handler
            IBody<ISensorData>      // HandlerOutput            
        >();
        
        StatusOutput<IBody<ISensorData>> value = await service.RunAsync(post, this.ApiProxyFactory(), true);
        var result = this.ToIActionResult<ViewSensorData, ISensorData>(value);
        return result;
    }
}