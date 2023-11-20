using Microsoft.AspNetCore.Mvc;
using Sensor.Api.Extension;
using Sensor.Api.Post;
using Sensor.Api.View;
using Sensor.Service.AttachmentService;
using Sensor.Service.Dto;
using Sensor.Service.Handler;
using Sensor.Service.Interface;
using Sensor.Service.Port;
using Sensor.Service.Port.Interface;

namespace Sensor.Api.Controllers.V1; 

public class Admin : ControllerExtensions {
    [HttpGet("/V1/Admin/Iot/Infos")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewBody<ViewIotInfos>))]
    public async Task<IActionResult> IotInfos() {
        var service = new AttachmentService<
            IInputNone,            // Input
            DtoInputNone,          // Dto
            HandlerAdminIotGetAll, // Handler
            IBody<IIotInfos>       // HandlerOutput            
        >();
        StatusOutput<IBody<IIotInfos>> value = await service.RunAsync(new PostInputNone(), this.ApiProxyFactory(), true);
        var result = this.ToIActionResult<ViewIotInfo, IIotInfos>(value);
        return result;
    }

    [HttpPost("/V1/Admin/Iot/Update")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewBody<ViewIotInfos>))]
    public async Task<IActionResult> IotInfos([FromBody] PostAdminIotUpdate post) {
        var service = new AttachmentService<
            IInputAdminIotUpdate,   // Input
            DtoInputAdminIotUpdate, // Dto
            HandlerAdminIotUpdate,  // Handler
            IBody<IIotInfos>        // HandlerOutput            
        >();
        StatusOutput<IBody<IIotInfos>> value = await service.RunAsync(post, this.ApiProxyFactory(), true);
        var result = this.ToIActionResult<ViewIotInfo, IIotInfos>(value);
        return result;
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
    public async Task<IActionResult> IotInsert([FromBody] PostAdminIotInsert post) {
        var service = new AttachmentService<
            IInputAdminIotInsert,    // Input
            DtoInputAdminIotInsert,  // Dto
            HandlerAdminIotInsert,   // Handler
            IBody<IIotInfos>         // HandlerOutput            
        >();
        StatusOutput<IBody<IIotInfos>> value = await service.RunAsync(post, this.ApiProxyFactory(), true);
        var result = this.ToIActionResult<ViewIotInfo, IIotInfos>(value);
        return result;
    }
    
    [HttpGet("/V1/Admin/User/All")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewBody<ViewUserInfos>))]
    public async Task<IActionResult> AdminUserAll() {
        var service = new AttachmentService<
            IInputNone,    // Input
            DtoInputNone,  // Dto
            HandlerAdminUserGetAll,   // Handler
            IBody<IUserInfos>         // HandlerOutput            
        >();
        StatusOutput<IBody<IUserInfos>> value = await service.RunAsync(new PostInputNone(), this.ApiProxyFactory(), true);
        var result = this.ToIActionResult<ViewUserInfos, IUserInfos>(value);
        return result;
    }
    
    [HttpPost("/V1/Admin/User/Add")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewBody<ViewUserInfos>))]
    public async Task<IActionResult> AdminUserAdd([FromBody] PostUserAdd post) {
        var service = new AttachmentService<
            IInputUserAdd,         // Input
            DtoInputUserAdd,       // Dto
            HandlerAdminUserAdd,   // Handler
            IBody<IUserInfos>      // HandlerOutput            
        >();
        StatusOutput<IBody<IUserInfos>> value = await service.RunAsync(post, this.ApiProxyFactory(), true);
        var result = this.ToIActionResult<ViewUserInfos, IUserInfos>(value);
        return result;
    }
    
    [HttpPost("/V1/Admin/User/Remove")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewBody<ViewUserInfos>))]
    public async Task<IActionResult> AdminUserRemove([FromBody] PostUserId post) {
        var service = new AttachmentService<
            IInputUserId,           // Input
            DtoUserId,              // Dto
            HandlerAdminUserRemove, // Handler
            IBody<IUserInfos>       // HandlerOutput            
        >();
        StatusOutput<IBody<IUserInfos>> value = await service.RunAsync(post, this.ApiProxyFactory(), true);
        var result = this.ToIActionResult<ViewUserInfos, IUserInfos>(value);
        return result;
    }
    
    [HttpPost("/V1/Admin/User/SetPassword")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewBody<ViewWork>))]
    public async Task<IActionResult> AdminUserSetPassword([FromBody] PostAdminSetUserPassword post) {
                    
    }
}