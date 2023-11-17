using Sensor.Service.AttachmentService.Interface;
using Sensor.Service.Port.Interface;

namespace Sensor.Service.Dto; 

public class DtoBody<T> : 
    IDto, 
    IBody<T>, 
    IDtoFrom<DtoBody<T>, IBody<T>>
    where T: class, IDto {
    
    public required T Data { get; set; }
    object? IBody.Data { get => Data; set => Data = (T)(object)value; }
    public required bool Error { get; set; }
    public required int ErrorId { get; set; }
    public required string ErrorMessage { get; set; }
    
    public static DtoBody<T> From(IBody<T> from) {
        return new DtoBody<T> {
            Data = from.Data,
            Error = from.Error,
            ErrorId = from.ErrorId,
            ErrorMessage = from.ErrorMessage,
        };
    }
}