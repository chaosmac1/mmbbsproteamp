using SensorLib.Class;

namespace SensorLib.AttachmentService.Interface; 

public interface IOutputTransform<HandlerOutput, Output> where Output: IView {
    public StatusOutput<Output> Transform(StatusOutput<HandlerOutput> output);
}