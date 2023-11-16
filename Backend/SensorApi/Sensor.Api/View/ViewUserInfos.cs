using Sensor.Api.Interface;

namespace Sensor.Api.View; 

public class ViewUserInfos: IView {
    public required ViewUserInfo List { get; set; }
}