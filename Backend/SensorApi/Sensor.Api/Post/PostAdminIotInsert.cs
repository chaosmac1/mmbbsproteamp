using Sensor.Service.AttachmentService.Interface;
using Sensor.Service.Interface;

namespace Sensor.Api.Post; 

public class PostAdminIotInsert: IInputAdminIotInsert, IInput {
    public required string Name { get; set; }
}