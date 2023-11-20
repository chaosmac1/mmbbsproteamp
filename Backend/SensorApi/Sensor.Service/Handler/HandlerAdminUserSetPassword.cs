using LamLibAllOver;
using Sensor.Domain;
using Sensor.Domain.Entity;
using Sensor.Domain.ValueObject;
using Sensor.Repository.Database;
using Sensor.Service.AttachmentService.Interface;
using Sensor.Service.Dto;
using Sensor.Service.Port;
using Sensor.Service.Port.Interface;

namespace Sensor.Service.Handler; 

public class HandlerAdminUserSetPassword: IHandler<DtoInputAdminSetUserPassword, IBody<IUserInfo>> {
    public async Task<StatusOutput<IBody<IUserInfo>>> HandlingAsync(
        DtoInputAdminSetUserPassword prop, 
        IDbWrapper dbWrapper, 
        IApiProxy apiProxy, 
        Option<UserIdAndToken> token) {

        var db = dbWrapper.Db;

        var userInfoOp = await ManagerUserInfo.GetUserInfoIsTokenUserIsAdminAsync(db, token.Unwrap().UserId);
        if (userInfoOp.IsNotSet()) {
            return StatusOutput<IBody<IUserInfo>>.AsOk(DtoBody<IUserInfo>.HasError(Error.UserIsNotAdmin));
        }

        var userInfo = userInfoOp.Unwrap();
        var passwordHash = Core.Utils.Password.CreateHash(prop.Password);

        var updateValue = new UserInfo(token.Unwrap().UserId) {
            Username = userInfo.Username,
            IsAdmin = userInfo.IsAdmin,
            PasswordHash = passwordHash
        };
        
        await ManagerUserInfo.UpdateByIdAsync(db, updateValue);
        
        return StatusOutput<IBody<IUserInfo>>.AsOk(DtoBody<IUserInfo>.NoError(new DtoUserInfo() {
            Username = updateValue.Username,
            UserId = updateValue.Id.Value
        }));
    }
}