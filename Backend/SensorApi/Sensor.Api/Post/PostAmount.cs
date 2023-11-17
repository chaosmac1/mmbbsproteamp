using Sensor.Service.AttachmentService.Interface;
using Sensor.Service.Port.Interface;

namespace Sensor.Api.Post; 

public class PostAmount: IAmount, IInput {
    public int Amount { get; set; }
}