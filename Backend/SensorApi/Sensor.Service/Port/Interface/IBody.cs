using Sensor.Service.AttachmentService.Interface;

namespace Sensor.Service.Port.Interface; 

public interface IBody<T>: IHandlerOutput, IBody where T: class  {
    public T? Data { get; set; }
    public bool Error { get; set; }
    public int ErrorId { get; set; }
    public string ErrorMessage { get; set; }
}

public interface IBody : IHandlerOutput {
    public object? Data { get; set; }
    public bool Error { get; set; }
    public int ErrorId { get; set; }
    public string ErrorMessage { get; set; }
}