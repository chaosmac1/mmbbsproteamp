using LamLibAllOver;
using Npgsql;
using Sensor.Domain;
using Sensor.Domain.Entity;
using Sensor.Repository.Database;
using Sensor.Service.Dto;
using Sensor.Service.Port;
using Sensor.Service.Port.Interface;

namespace Sensor.Service.AttachmentService.Interface;

public interface IHandler<HandlerInput, HandlerOutput> {
    public Task<StatusOutput<HandlerOutput>> HandlingAsync(
        HandlerInput prop,  
        IDbWrapper dbWrapper, 
        IApiProxy apiProxy,
        Option<Sensor.Domain.ValueObject.UserIdAndToken> token);


}