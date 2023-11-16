using Sensor.Domain.ValueObject;
using Sensor.Service.Port.Interface;

namespace Sensor.Api.Post; 

public class PostAdminIotUpdate: IInputAdminIotUpdate<PostCanNull<string>> {
    public required string IotId { get; set; }
    public required PostCanNull<string> UpdateId { get; set; }
    public required bool AllowedRequest { get; set; }
}