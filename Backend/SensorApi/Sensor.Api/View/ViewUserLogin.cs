using Sensor.Api.Interface;
using Sensor.Domain.Enum;

namespace Sensor.Api.View; 

public class ViewUserLogin: IView {
    public EUserLogin Status { get; set; }
}