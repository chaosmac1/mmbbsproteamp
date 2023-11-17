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

public class Admin : ControllerExtensions {
    [HttpGet("/V1/Admin/Iot/Infos")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewBody<ViewIotInfos>))]
    public Task<IActionResult> IotInfos() {
        throw new NotImplementedException(nameof(IotInfos));
    }

    [HttpPost("/V1/Admin/Iot/Update")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewBody<ViewIotInfo>))]
    public Task<IActionResult> IotInfos([FromBody] PostAdminIotUpdate post) {
        throw new NotImplementedException(nameof(IotInfos));
    }

    [HttpPost("/V1/Admin/Iot/Delete")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewBody<ViewIotInfos>))]
    public async Task<IActionResult> IotDelete([FromBody] PostAdminIotDelete post) {
        var service = new AttachmentService<
            IInputAdminIotDelete,    // Input
            DtoInputAdminIotDelete,  // Dto
            HandlerIotDelete,        // Handler
            IBody<IIotInfos>         // HandlerOutput            
        >();
        StatusOutput<IBody<IIotInfos>> value = await service.RunAsync(post, this.ApiProxyFactory(), true);
        var result = this.ToIActionResult<ViewIotInfo, IIotInfos>(value);
        return result;
    }
    
    [HttpPost("/V1/Admin/Iot/Insert")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewBody<ViewIotInfos>))]
    public Task<IActionResult> IotInsert([FromBody] PostAdminIotInsert post) {
        throw new NotImplementedException(nameof(IotInsert));
    }
    
    [HttpGet("/V1/Admin/User/All")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewBody<ViewUserInfos>))]
    public IResult AdminUserAll() {
        throw new NotImplementedException(nameof(AdminUserAll));
    }
    
    [HttpPost("/V1/Admin/User/Add")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewBody<ViewUserInfo>))]
    public IResult AdminUserAdd([FromBody] PostUserAdd post) {
        throw new NotImplementedException(nameof(AdminUserAdd));
    }
    
    [HttpPost("/V1/Admin/User/Remove")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewBody<ViewUserInfos>))]
    public IResult AdminUserRemove([FromBody] PostUserId post) {
        throw new NotImplementedException(nameof(AdminUserRemove));
    }
    
    [HttpPost("/V1/Admin/User/SetPassword")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewBody<ViewWork>))]
    public IResult AdminUserSetPassword([FromBody] PostAdminSetUserPassword post) {
        throw new NotImplementedException(nameof(AdminUserSetPassword));
    }
}