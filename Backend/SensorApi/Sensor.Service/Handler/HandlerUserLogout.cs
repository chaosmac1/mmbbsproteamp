using LamLibAllOver;
using Sensor.Domain.ValueObject;
using Sensor.Repository.Database;
using Sensor.Service.AttachmentService.Interface;
using Sensor.Service.Dto;
using Sensor.Service.Port;
using Sensor.Service.Port.Interface;

namespace Sensor.Service.Handler; 

public class HandlerUserLogout: IHandler<DtoInputNone, IBody<IWork>> {
    public async Task<StatusOutput<IBody<IWork>>> HandlingAsync(
        DtoInputNone prop, 
        IDbWrapper dbWrapper, 
        IApiProxy apiProxy, 
        Option<UserIdAndToken> token) {

        throw new NotImplementedException(nameof(HandlerUserLogout));
    }
}