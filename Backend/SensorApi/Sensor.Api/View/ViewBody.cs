using Newtonsoft.Json;
using Sensor.Api.Interface;
using Sensor.Service.Port.Interface;

namespace Sensor.Api.View; 

public class ViewBody<T> where T: class, IView {
    public T? Data { get; set; }
    public bool Error { get; set; }
    public int ErrorId { get; set; }
    public string? ErrorMessage { get; set; }
}