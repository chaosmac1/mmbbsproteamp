using LamLibAllOver;
using Sensor.Domain.Interface;
using Sensor.Domain.ValueObject;
using Sensor.Service.AttachmentService.Interface;
using Sensor.Service.Dto;
using Sensor.Service.Port;
using Sensor.Service.Port.Interface;

namespace Sensor.Service.Handler; 

public struct HandlerIotDelete: IHandler<DtoInputAdminIotDelete, IBody<IIotInfos>> {
    public Task<StatusOutput<IBody<IIotInfos>>> HandlingAsync(
        DtoInputAdminIotDelete prop, 
        IDbWrapper dbWrapper, 
        IApiProxy apiProxy, 
        Option<UserIdAndToken> token) {
        
        throw new NotImplementedException();
    }
}