using Sensor.Service.Interface;

namespace Sensor.Api.Post; 

public class PostAdminIotInsert: IInputAdminIotInsert {
    public required string IotId { get; set; }
}