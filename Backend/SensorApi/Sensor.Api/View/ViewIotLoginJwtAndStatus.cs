using Sensor.Api.Interface;
using Sensor.Domain.Enum;
using Sensor.Domain.ValueObject;

namespace Sensor.Api.View; 

public class ViewIotLoginJwtAndStatus: IView {
    public required string Status { get; set; }
    public required IotToken Token { get; set; }
}