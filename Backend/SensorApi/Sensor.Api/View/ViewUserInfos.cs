using Sensor.Api.Interface;

namespace Sensor.Api.View; 

public class ViewUserInfos: IView {
    public required IList<ViewUserInfo> List { get; set; }
}