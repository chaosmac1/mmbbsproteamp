using LamLibAllOver;
using Sensor.Repository.Database;
using Sensor.Service.Port; 

namespace Sensor.Service.AttachmentService.Interface;

public interface IHandler<HandlerInput, HandlerOutput>
    where HandlerInput: IDto
    where HandlerOutput: IHandlerOutput {
    public Task<StatusOutput<HandlerOutput>> HandlingAsync(
        HandlerInput prop,  
        IDbWrapper dbWrapper, 
        IApiProxy apiProxy,
        Option<Sensor.Domain.ValueObject.UserIdAndToken> token);
}