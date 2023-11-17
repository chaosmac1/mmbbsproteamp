using LamLibAllOver;
using Sensor.Domain.Interface;
using Sensor.Service.Port; 
using Sensor.Service.Port.Interface;

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