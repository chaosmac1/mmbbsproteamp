using LamLibAllOver;
using Sensor.Service.Port; 
using Sensor.Core.Database;
using Sensor.Service.Port.Interface;

namespace Sensor.Service.AttachmentService.Interface;

public interface IHandler<HandlerInput, HandlerOutput>
    where HandlerInput: IDto
    where HandlerOutput: IHandlerOutput {
    public Task<StatusOutput<HandlerOutput>> HandlingAsync(
        HandlerInput prop,  
        Sensor.Core.Database.DbWrapper dbWrapper, 
        IController controller,
        Option<IUserIdAndToken> token);
}