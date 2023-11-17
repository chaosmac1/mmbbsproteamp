using Sensor.Service.AttachmentService.Interface;
using Sensor.Service.Port.Interface;

namespace Sensor.Api.Post; 

public class PostAdminSetUserPassword: IInputAdminSetUserPassword, IInput {
    public required Guid UserId { get; set; }
    public required string Password { get; set; }
}