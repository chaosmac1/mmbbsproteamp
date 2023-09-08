using LamLibAllOver;
using SensorLib.Class;
using SensorLib.Database;
using SensorLib.Record;

namespace SensorLib.AttachmentService.Interface; 

public interface IHandler<HandlerInput, HandlerOutput> where HandlerOutput: IHandlerOutput {
    public ValueTask<StatusOutput<HandlerOutput>> HandlingAsync(
        HandlerInput request,  
        DbWrapper dbWrapper, 
        IController controller,
        Option<UserIdAndToken> token);
}