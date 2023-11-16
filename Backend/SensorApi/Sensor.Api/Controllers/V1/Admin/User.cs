using Microsoft.AspNetCore.Mvc;
using Sensor.Api.Post;
using Sensor.Api.View;

namespace Sensor.Api.Controllers.V1.Admin; 

public class User : ControllerBase {
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