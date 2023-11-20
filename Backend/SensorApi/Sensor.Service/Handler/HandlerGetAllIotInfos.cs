using Dapper;
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

public struct HandlerGetAllIotInfos: IHandler<DtoNone, IBody<IIotInfos>> {
    public async Task<StatusOutput<IBody<IIotInfos>>> HandlingAsync(
        DtoNone prop, 
        IDbWrapper dbWrapper, 
        IApiProxy apiProxy, 
        Option<UserIdAndToken> token) {

        var db = dbWrapper.Db;
        var userInfo = await ManagerUserInfo.FindByIdAsync(db, token.Unwrap().UserId );
        if (userInfo.IsNotSet()) {
            return StatusOutput<IBody<IIotInfos>>
                .AsBadRequestWithMessage(DtoBody<IIotInfos>.HasError(Error.UserNotFoundByCookie));
        }
        
        var result = (await ManagerIotDevice.AllAsync(db)).Select(x => (DtoIotInfo)x).AsList();

        var body = DtoBody<IIotInfos>.NoError(new DtoIotInfos { List = result });
        return StatusOutput<IBody<IIotInfos>>.AsOk(body);
    }
}