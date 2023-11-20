using LamLibAllOver;
using Sensor.Domain.ValueObject;
using Sensor.Repository.Database;
using Sensor.Service.AttachmentService.Interface;
using Sensor.Service.Dto;
using Sensor.Service.Port;
using Sensor.Service.Port.Interface;

namespace Sensor.Service.Handler; 

public class HandlerAdminUserSetPassword: IHandler<DtoInputAdminSetUserPassword, IBody<IUserInfo>> {
    public Task<StatusOutput<IBody<IUserInfo>>> HandlingAsync(
        DtoInputAdminSetUserPassword prop, 
        IDbWrapper dbWrapper, 
        IApiProxy apiProxy, 
        Option<UserIdAndToken> token) {

        
        
        var passwordHash = Core.Utils.Password.CreateHash(prop.Password);
    }
}