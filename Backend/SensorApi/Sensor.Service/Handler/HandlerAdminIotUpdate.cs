using Dapper;
using LamLibAllOver;
using Npgsql;
using Sensor.Domain;
using Sensor.Domain.Entity;
using Sensor.Domain.ValueObject;
using Sensor.Repository.Database;
using Sensor.Service.AttachmentService.Interface;
using Sensor.Service.Dto;
using Sensor.Service.Port;
using Sensor.Service.Port.Interface;

namespace Sensor.Service.Handler; 

public struct HandlerAdminIotUpdate: IHandler<DtoInputAdminIotUpdate, IBody<IIotInfos>> {
    public async Task<StatusOutput<IBody<IIotInfos>>> HandlingAsync(
        DtoInputAdminIotUpdate prop, 
        IDbWrapper dbWrapper, 
        IApiProxy apiProxy, 
        Option<UserIdAndToken> token) {

        var db = dbWrapper.Db;
        var userInfo = await ManagerUserInfo.FindByIdAsync(db, token.Unwrap().UserId );
        if (userInfo.IsNotSet()) {
            return StatusOutput<IBody<IIotInfos>>
                .AsBadRequestWithMessage(DtoBody<IIotInfos>.HasError(Error.UserNotFoundByCookie));
        }

        if (!userInfo.Unwrap().IsAdmin) {
            return StatusOutput<IBody<IIotInfos>>.AsOk(DtoBody<IIotInfos>.HasError(Error.UserIsNotAdmin));
        }
        
        var updateTargetOp = await ManagerIotDevice.FindByIdAsync(db, new () { Value = prop.IotId });
        if (updateTargetOp.IsNotSet()) {
            return StatusOutput<IBody<IIotInfos>>
                .AsBadRequestWithMessage(DtoBody<IIotInfos>.HasError(Error.UpdateTargetNotFound));
        }

        var updateTarget = updateTargetOp.Unwrap();

        if (updateTarget.Name == prop.Name) {
            await ManagerIotDevice.UpdateIotDeviceFindByIdAsync(db, new IotDevice(updateTarget.Id) {
                Name = prop.Name,
                AllowedRequest = prop.AllowedRequest,
                LastRequest = updateTarget.LastRequest
            });
        }
        else {
            var exit = (await ManagerIotDevice.FindByNameAsync(db, prop.Name)).IsSet();

            if (exit) {
                return StatusOutput<IBody<IIotInfos>>.AsOk(DtoBody<IIotInfos>.HasError(Error.IotNameExist));
            }
            
            await ManagerIotDevice.UpdateIotDeviceFindByIdAsync(db, new IotDevice(updateTarget.Id) {
                Name = prop.Name,
                AllowedRequest = prop.AllowedRequest,
                LastRequest = updateTarget.LastRequest
            });
        }
        
        var result = (await ManagerIotDevice.AllAsync(db)).Select(x => (DtoIotInfo)x).AsList();

        var body = DtoBody<IIotInfos>.NoError(new DtoIotInfos { List = result });
        return StatusOutput<IBody<IIotInfos>>.AsOk(body);
    }
}