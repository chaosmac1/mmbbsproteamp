using LamLibAllOver;
using Sensor.Domain.Entity;
using Sensor.Domain.ValueObject;
using Sensor.Repository.Database;
using Sensor.Service.AttachmentService.Interface;
using Sensor.Service.Dto;
using Sensor.Service.Port;
using Sensor.Service.Port.Interface;

namespace Sensor.Service.Handler; 

public class HandlerLoginUser: IHandler<DtoInputUserLogin, IBody<IUserLoginStatus>> {
    public async Task<StatusOutput<IBody<IUserLoginStatus>>> HandlingAsync(
        DtoInputUserLogin prop, 
        IDbWrapper dbWrapper, 
        IApiProxy apiProxy, 
        Option<UserIdAndToken> token) {

        var db = dbWrapper.Db;
        

        var userInfoOp = await ManagerUserInfo.FindByUsernameAsync(db, prop.Username);
        if (userInfoOp.IsNotSet()) {
            return StatusOutput<IBody<IUserLoginStatus>>.AsOk(DtoBody<IUserLoginStatus>.NoError(new DtoUserLoginStatus {
                Status = Domain.Enum.EUserLogin.UsernameFalse.ToString()
            }));
        }
        
        var userInfo = userInfoOp.Unwrap();
        
        if (!Core.Utils.Password.Valid(prop.Password, userInfo.PasswordHash)) {
            return StatusOutput<IBody<IUserLoginStatus>>.AsOk(DtoBody<IUserLoginStatus>.NoError(new DtoUserLoginStatus {
                Status = Domain.Enum.EUserLogin.PasswordFalse.ToString()
            })); 
        }

        var userCookie = UserCookie.NewCookie(userInfo.Id);

        await ManagerUserCookie.InsertAsync(db, userCookie);
        
        apiProxy.SetCookie(DtoUserToken.From(userCookie.Id));
        
        return StatusOutput<IBody<IUserLoginStatus>>.AsOk(DtoBody<IUserLoginStatus>.NoError(new DtoUserLoginStatus {
            Status = Domain.Enum.EUserLogin.Work.ToString()
        }));
    }
}