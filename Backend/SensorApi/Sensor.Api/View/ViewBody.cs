using Sensor.Api.Interface;

namespace Sensor.Api.View; 

public class ViewBody<T> where T: IView {
    public T? Data { get; set; }
    public bool Error { get; set; }
    public int ErrorId { get; set; }
    public string? ErrorMessage { get; set; }
}