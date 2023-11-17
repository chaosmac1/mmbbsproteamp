using Sensor.Api.Interface;

namespace Sensor.Api.View; 

public class ViewValid: IView {
    public required bool IsValid { get; set; }
    public required DateTime ValidEndDate { get; set; }
}