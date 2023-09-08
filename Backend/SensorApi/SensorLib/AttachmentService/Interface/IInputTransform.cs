namespace SensorLib.AttachmentService.Interface; 

public interface IInputTransform<Input, HandlerInput> where Input: IRequest {
    public HandlerInput Transform(Input value);
}