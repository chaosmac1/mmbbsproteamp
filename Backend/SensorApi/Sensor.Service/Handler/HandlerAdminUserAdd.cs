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

public class HandlerAdminUserAdd: IHandler<DtoInputUserAdd, IBody<IUserInfos>> {
    public async Task<StatusOutput<IBody<IUserInfos>>> HandlingAsync(DtoInputUserAdd prop, IDbWrapper dbWrapper, IApiProxy apiProxy, Option<UserIdAndToken> token) {
        var db = dbWrapper.Db;
        var userInfo = await ManagerUserInfo.FindByIdAsync(db, token.Unwrap().UserId );
        if (userInfo.IsNotSet()) {
            return StatusOutput<IBody<IUserInfos>>
                .AsBadRequestWithMessage(DtoBody<IUserInfos>.HasError(Error.UserNotFoundByCookie));
        }

        if (!userInfo.Unwrap().IsAdmin) {
            return StatusOutput<IBody<IUserInfos>>.AsOk(DtoBody<IUserInfos>.HasError(Error.UserIsNotAdmin));
        }


        var exit = (await ManagerUserInfo.FindByUsernameAsync(db, prop.Username)).IsSet();
        if (!exit) {
            return StatusOutput<IBody<IUserInfos>>.AsOk(DtoBody<IUserInfos>.HasError(Error.UserWithName));
        }

        await ManagerUserInfo.InsertAsync(db, new UserInfo(UserId.NewUserId()) {
            Username = prop.Username,
            IsAdmin = false,
            PasswordHash = prop.Password
        });
        
        var list = await ManagerUserInfo.GetAllAsync(db);
        var dtoUserInfos = list.Select(info => new DtoUserInfo() {
            Username = info.Username,
            UserId = info.Id.Value
        }.AsIUserInfo).ToList();

        return StatusOutput<IBody<IUserInfos>>.AsOk(DtoBody<IUserInfos>.NoError(new DtoUserInfos() {
            List = dtoUserInfos
        }));
    }
}