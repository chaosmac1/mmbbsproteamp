using Sensor.Service.Port.Interface;

namespace Sensor.Api.Post; 

public class PostAdminIotDelete: IInputAdminIotDelete {
    public required string IotId { get; init; }
}